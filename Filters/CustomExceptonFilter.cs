using CustomerApi.Exceptions;
using Microsoft.AspNetCore.JsonPatch.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomerApi.Filters
{
    public class CustomExceptonFilter : ExceptionFilterAttribute
    {
        ApiError apiError = null;
        public override void OnException(ExceptionContext context)
        {
            if(context.Exception is JsonPatchException) {

                context.HttpContext.Response.StatusCode = 400;
                apiError = new ApiError("Invalid Patch Json", context.Exception.Message);

            } else {
                var message = "Unable to complete request at this time";
                context.HttpContext.Response.StatusCode = 500;
                apiError = new ApiError(message);
            }

            context.Result = new JsonResult(apiError);
            base.OnException(context);
        }
    }
}