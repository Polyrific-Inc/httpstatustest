using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyrific.Middleware.HttpStatusTest
{
    public static class HttpStatusTestExtensions
    {
        /// <summary>
        /// Inject the HttpStatus Test middleware to the request pipeline
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseHttpStatusTest(this IApplicationBuilder app)
        {
            return app.UseHttpStatusTest(null);
        }

        /// <summary>
        /// Inject the HttpStatus Test middleware to the request pipeline with some custom configurations
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configureConfig">The custom configurations</param>
        /// <returns></returns>
        public static IApplicationBuilder UseHttpStatusTest(this IApplicationBuilder app, Action<HttpStatusTestConfig> configureConfig)
        {
            var config = new HttpStatusTestConfig();

            if (configureConfig != null)
                configureConfig(config);

            return app.UseMiddleware<HttpStatusTestMiddleware>(config);
        }
    }
}
