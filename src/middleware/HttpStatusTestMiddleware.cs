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

        public HttpStatusTestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/httpstatus")
            {
                var expectedCode = context.Request.Query["c"];
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
