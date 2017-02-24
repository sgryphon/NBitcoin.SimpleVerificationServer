using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using NBitcoin.SimpleVerificationServer.Web;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace NBitcoin.SimpleVerificationServer
{
    public class Shell : IDisposable
    {
        // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection

        bool _disposed = false;
        bool _isRunning = false;
        public ILogger _logger;

        public Shell()
        {
        }

        public IConfigurationRoot Configuration { get; private set; }

        public ILoggerFactory LoggerFactory { get; private set; }

        public Node Node { get; set; }

        public IServiceProvider Services { get; private set; }

        public IWebHost WebHost { get; private set; }

        public void Start()
        {
            Console.WriteLine("Starting Simple Verification Server shell");

            Configuration = BuildConfiguration();
            LoggerFactory = BuildLoggerFactory(Configuration);

            _logger = LoggerFactory.CreateLogger<Shell>();
            _logger.LogInformation(1000, "Logging configured");

            // Build webhost first, as ASP.NET wants to create service provider & logger
            WebHost = BuildWebHostAndServiceProvider(Configuration, LoggerFactory, services => ConfigureServices(services));
            Services = WebHost.Services;

            // Build other components
            Node = BuildNode(Services);

            _logger.LogDebug("Starting components");
            Node.Start();
            WebHost.Start();
        }

        public void Stop()
        {
            _logger.LogDebug("Stopping");
        }

        private IConfigurationRoot BuildConfiguration()
        {
            var configBuilder = new ConfigurationBuilder()
                //.SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            //if (env.IsDevelopment())
            //{
            //    // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
            //    builder.AddUserSecrets();
            //    // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
            //    builder.AddApplicationInsightsSettings(developerMode: true);
            //}
            configBuilder.AddEnvironmentVariables();
            var configuration = configBuilder.Build();
            return configuration;
        }

        private ILoggerFactory BuildLoggerFactory(IConfigurationRoot configuration)
        {
            //Console.WriteLine("CONSOLE: Creating logger factory");
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddConsole(configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            return loggerFactory;
        }

        private Node BuildNode(IServiceProvider services)
        {
            var node = services.GetRequiredService<Node>();
            return node;
        }

        private IWebHost BuildWebHostAndServiceProvider(IConfiguration configuration, ILoggerFactory loggerFactory, Action<IServiceCollection> configureServices)
        {
            var webHostBuilder = new WebHostBuilder()
                .UseIISIntegration()
                .UseKestrel()
                .UseConfiguration(configuration)
                .UseLoggerFactory(loggerFactory)
                .UseStartup<Startup>()
                .ConfigureServices(configureServices);
            //Console.WriteLine("CONSOLE: WebHostBuilder ready, about to Build");
            _logger.LogDebug("WebHostBuilder ready, about to Build");
            var webHost = webHostBuilder.Build();
            return webHost;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //Console.WriteLine("CONSOLE: Builder configure services");
            _logger.LogDebug("Shell configure services");

            // Register our non-web services
            services.AddSingleton<Node>();
            services.Configure<NodeSettings>(Configuration.GetSection("Node"));
            return;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_isRunning)
                {
                    Stop();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
