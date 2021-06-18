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
            return app.UseMiddleware<HttpStatusTestMiddleware>();
        }
    }
}
