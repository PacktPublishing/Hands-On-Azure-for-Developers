using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HandsOnAzureStateless
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }

        public Startup(IApplicationBuilder appenv, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Run(context => {
                return context.Response.WriteAsync("Hello From Service Fabric!");
            });
        }
    }
}