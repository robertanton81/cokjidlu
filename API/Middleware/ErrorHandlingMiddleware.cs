using Application.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task Invoke(HttpContext ctx)
        {
            try
            {
                await _next(ctx);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(ctx, ex, _logger);
            }
        }

        private async Task HandleExceptionAsync(HttpContext ctx, Exception ex, ILogger<ErrorHandlingMiddleware> logger)
        {
            object errors = null;

            switch (ex)
            {
                case RestExceptions re:
                    logger.LogError(ex, "REST error");
                    errors = re.Errors;
                    ctx.Response.StatusCode = (int)re.Code;
                    break;
                case Exception e:
                    logger.LogError(e, "REST error");
                    errors = string.IsNullOrWhiteSpace(e.Message) ? "some other error" : e.Message;
                    ctx.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
                default:
                    break;
            }

            ctx.Response.ContentType = "application/json";
            if (errors != null)
            {
                var result = JsonSerializer.Serialize(new
                {
                    errors
                });

                await ctx.Response.WriteAsync(result);
            }
        }
    }
}
