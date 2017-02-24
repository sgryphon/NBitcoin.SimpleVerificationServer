using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace NBitcoin.SimpleVerificationServer.Web
{
    public class Startup
    {
        ILogger _logger; 

        public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //Console.WriteLine("CONSOLE: Startup ctor");
            _logger = loggerFactory.CreateLogger<Startup>();
            _logger.LogDebug("Startup ctor");
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //Console.WriteLine("CONSOLE: Startup ConfigureServices");
            _logger.LogDebug("Startup ConfigureServices");

            // ASP.NET Core docs for Autofac are here:
            // http://autofac.readthedocs.io/en/latest/integration/aspnetcore.html
            //
            // Add framework services.
            services.AddMvc();

            //// Create the Autofac container builder.
            //var builder = new ContainerBuilder();
            //// Populate the services.
            //builder.Populate(services);
            //// Build the container.
            //this.ApplicationContainer = builder.Build();
            //// Create and return the service provider.
            //return new AutofacServiceProvider(this.ApplicationContainer);
            return null;
        }

        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            IApplicationLifetime appLifetime)
        {
            //Console.WriteLine("CONSOLE: Startup Configure");
            _logger.LogDebug("Startup Configure");

            app.UseMvc();

            // If you want to dispose of resources that have been resolved in the
            // application container, register for the "ApplicationStopped" event.
            //appLifetime.ApplicationStopped.Register(() => this.ApplicationContainer.Dispose());
        }
    }
}
