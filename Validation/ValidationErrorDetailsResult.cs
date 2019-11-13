using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Validation
{
    public class ValidationErrorDetailsResult : IActionResult
    {
        public Task ExecuteResultAsync(ActionContext context)
        {
            var modelStateEntries = context.ModelState.Where(e => e.Value.Errors.Count > 0).ToArray();
            
            var errors = new List<ValidationError>();

            var details = "See Errors for details";

            if (modelStateEntries.Any())
            {
                if (modelStateEntries.Length == 1 && modelStateEntries[0].Value.Errors.Count == 1 && modelStateEntries[0].Key == string.Empty)
                {
                    details = modelStateEntries[0].Value.Errors[0].ErrorMessage;
                }
                else
                {
                    foreach (var modelStateEntry in modelStateEntries)
                    {
                        foreach (var modelStateError in modelStateEntry.Value.Errors)
                        {
                            var error = new ValidationError
                            {
                                name = modelStateEntry.Key,
                                description = modelStateError.ErrorMessage
                            };

                            errors.Add(error);
                        }
                    }
                }
            }

            var problemDetails = new CustomValidationProblemDetails
            {
                Status = 400,
                Title = "Request Validation Error",
                Detail = details,
                errors = errors
            };

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = 400;
            context.HttpContext.Response.WriteAsync(JsonSerializer.Serialize<CustomValidationProblemDetails>(problemDetails));
            return Task.CompletedTask;
        }
    }

      
}