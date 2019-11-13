using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Validation
{
    public class CustomValidationProblemDetails : ProblemDetails
    {
        public ICollection<ValidationError> errors { get; set; }
    }
}