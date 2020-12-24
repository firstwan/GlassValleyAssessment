using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassValley.Attributes
{
    public class ModelStateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsList = context.ModelState
                .SelectMany(m => m.Value.Errors)
                .Select(m => m.ErrorMessage);

                var errors = string.Join(string.Empty, errorsList.ToList());
                context.Result = new BadRequestObjectResult(errors);
            }
            else
                base.OnActionExecuting(context);
        }
    }
}
