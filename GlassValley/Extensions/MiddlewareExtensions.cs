using GlassValley.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassValley.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void CustomMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandleMiddleWare>();
        }
    }
}
