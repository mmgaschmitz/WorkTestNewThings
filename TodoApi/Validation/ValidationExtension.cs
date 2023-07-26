using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TodoApi.Validation
{
    public static class ValidationExtension
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            modelState.AddModelError("type", "https://tools.ietf.org/html/rfc7231#section-6.5.1");
            modelState.AddModelError("title", "Bad Request");
            modelState.AddModelError("status", "400");
            modelState.AddModelError("traceId", result.GetHashCode().ToString());


            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

        }
    }
}
