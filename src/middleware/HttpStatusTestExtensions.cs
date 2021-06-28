using Microsoft.AspNetCore.Builder;
using System;

#if (!NETCOREAPP2_1)
using Microsoft.AspNetCore.Routing;
#endif

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

            configureConfig?.Invoke(config);

            if (config.IsEnabled)
                return app.Map(config.TestPath, builder => builder.UseMiddleware<HttpStatusTestMiddleware>(config));
            
            return app;
        }

#if (!NETCOREAPP2_1)
        /// <summary>
        /// Inject the HttpStatus Test endpoint
        /// </summary>
        /// <param name="endpoints"></param>
        /// <returns></returns>
        public static IEndpointConventionBuilder MapHttpStatusTest(this IEndpointRouteBuilder endpoints)
        {
            return endpoints.MapHttpStatusTest(null);
        }

        /// <summary>
        /// Inject the HttpStatus Test endpoint with some custom configurations
        /// </summary>
        /// <param name="endpoints"></param>
        /// <param name="configureConfig">The custom configurations</param>
        /// <returns></returns>
        public static IEndpointConventionBuilder MapHttpStatusTest(this IEndpointRouteBuilder endpoints, Action<HttpStatusTestConfig> configureConfig)
        {
            var config = new HttpStatusTestConfig();

            configureConfig?.Invoke(config);

            var appBuilder = endpoints.CreateApplicationBuilder();

            if (config.IsEnabled)
            {
                var pipeline = appBuilder
                    .UseMiddleware<HttpStatusTestMiddleware>(config)
                    .Build();
                
                return endpoints.Map(config.TestPath, pipeline).WithDisplayName("HTTP Status Test");
            }

            return null;
        }
#endif

    }
}
