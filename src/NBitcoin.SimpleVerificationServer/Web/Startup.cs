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
            _logger = loggerFactory.CreateLogger<Startup>();
            //_logger.LogDebug("Startup ctor");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            _logger.LogDebug("Startup ConfigureServices");

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            IApplicationLifetime appLifetime)
        {
            _logger.LogDebug("Startup Configure");

            app.UseMvc();
        }
    }
}
