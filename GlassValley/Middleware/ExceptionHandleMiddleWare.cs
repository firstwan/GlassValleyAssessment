using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlassValley.Model;

namespace GlassValley.Middleware
{
    /// <summary>
    /// This middleware is for handle exception
    /// </summary>
    public class ExceptionHandleMiddleWare
    {
        private readonly RequestDelegate _next;

        public ExceptionHandleMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleUnExpectedException(httpContext, ex);
            }
        }


        /// <summary>
        /// To handle unexpected exception
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private Task HandleUnExpectedException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var exceptionModel = new ExceptionMessageModel()
            {
                ErrorCode = "999",
                ErrorMessage = "Unexpected error happen."
            };

            return context.Response.WriteAsync(exceptionModel.ToString());
        }
    }
}


