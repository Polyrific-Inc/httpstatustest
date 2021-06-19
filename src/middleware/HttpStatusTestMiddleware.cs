using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Polyrific.Middleware.HttpStatusTest
{
    /// <summary>
    /// Middleware to add an endpoint for the HttpStatus Test
    /// </summary>
    public class HttpStatusTestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HttpStatusTestConfig _config;

        public HttpStatusTestMiddleware(RequestDelegate next, HttpStatusTestConfig config)
        {
            _next = next;
            _config = config;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == _config.TestPath)
            {
                var expectedCode = context.Request.Query[_config.CodeKeyName];
                if (!string.IsNullOrEmpty(expectedCode) && int.TryParse(expectedCode, out int code))
                    context.Response.StatusCode = code;
                else
                    context.Response.StatusCode = StatusCodes.Status200OK;

                return;
            }

            await _next(context);
        }
    }
}
