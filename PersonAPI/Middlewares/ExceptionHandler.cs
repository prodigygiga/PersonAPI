using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PersonDirectory.Application.Commons;
using PersonDirectory.Application.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace PersonDirectory.Presentation.WebApi.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;
        private readonly IWebHostEnvironment env;

        public ExceptionHandler(RequestDelegate next, IWebHostEnvironment env, ILogger<ExceptionHandler> logger) =>
            (this.next, this.env, this.logger) = (next, env, logger);


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string titleText = "Internal Server Error.";
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var traceId = Activity.Current?.Id ?? context?.TraceIdentifier;

            //var user = new CurrentUserService(context);

            switch (exception)
            {
                case EntityValidationException e:
                    titleText = "One or more validation errors occurred.";
                    statusCode = (int)e.StatusCode;
                    logger.LogWarning(exception.Message);
                    //logger.LogError(exception, exception.Message + ": {@AccountType}, {@AccountId}", user.AccountType, user.AccountId);
                    break;
                case ValidationException _:
                    logger.LogWarning(exception.Message);
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case Exception _:
                    logger.LogError(exception, exception.Message);
                    if (env.IsProduction()) exception = new Exception("Internal Server Error");
                    break;
            }


            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(
            JsonConvert.SerializeObject(Result.Failure(
                titleText: titleText,
                statusCode: statusCode,
                traceId: traceId,
                exception: exception
            )));
        }
    }
}
