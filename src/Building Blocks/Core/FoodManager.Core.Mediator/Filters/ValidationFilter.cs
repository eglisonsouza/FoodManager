using FoodManager.Core.Mediator.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace FoodManager.Core.Mediator.Filters
{
    public class ValidationFilter : IActionFilter
    {
        private readonly ILogger<ValidationFilter> _logger;

        public ValidationFilter(ILogger<ValidationFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(CustomResult.Fail("Invalid request.", GetMessages(context.ModelState)));
                _logger.LogError("{actionDescription} - {modelState}", context.ActionDescriptor.DisplayName, string.Join(";", GetMessages(context.ModelState)!));
            }
        }

        private string[]? GetMessages(ModelStateDictionary modelState)
        {
            return modelState.SelectMany(m => m.Value!.Errors).Select(e => e.ErrorMessage).ToArray();
        }
    }
}
