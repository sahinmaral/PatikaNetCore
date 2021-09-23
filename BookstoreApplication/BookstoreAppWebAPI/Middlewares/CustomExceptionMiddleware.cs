using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BookstoreAppWebAPI.Middlewares
{
    public class CustomExceptionMiddleware
    {
        public readonly RequestDelegate RequestDelegate;

        public CustomExceptionMiddleware(RequestDelegate requestDelegate)
        {
            RequestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {

            if (context.Request.Path.ToString().StartsWith("/api"))
            {
                Stopwatch watch = new Stopwatch();

                try
                {
                    watch.Start();

                    string message = $"HTTP {context.Request.Method}  - {context.Request.Path}";
                    Console.WriteLine(message);

                    await RequestDelegate(context);

                    watch.Stop();
                    message = $"[Response] HTTP {context.Request.Method}  - {context.Request.Path} - Status Code : {context.Response.StatusCode} in {watch.Elapsed.TotalMilliseconds}";
                    Console.WriteLine(message);

                    watch.Reset();
                }
                catch (Exception exception)
                {
                    watch.Stop();
                    await HandleException(context, exception, watch);
                }
                

            }
            
        }

        private Task HandleException(HttpContext context, Exception exception, Stopwatch watch)
        {
            string message = $"[Error] Http {context.Request.Method} - {context.Response.StatusCode} - Error Message : {exception.Message} - Elapsed Time : {watch.Elapsed.TotalMilliseconds}";

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var result = JsonConvert.SerializeObject(new {error = exception.Message,Formatting.None});

            return context.Response.WriteAsync(result);

        }
    }

    public static class CustomExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomException(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
