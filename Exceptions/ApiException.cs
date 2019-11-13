using System;
using System.Collections.Generic;

namespace CustomerApi.Exceptions
{
    public class ApiException : Exception
    {
        public int StatusCode { get; set; }

        public IEnumerable<ApiError> Errors { get; set; }

        public ApiException(string message, int statusCode = 500, IEnumerable<ApiError> errors = null) :
            base(message)
        {
            StatusCode = statusCode;
            Errors = errors;
        }
        public ApiException(Exception ex, int statusCode = 500) : base(ex.Message)
        {
            StatusCode = statusCode;
        }
    }


    public class ApiError {
        public string message { get; set; }
        public string detail { get; set; }

        public ApiError (string message) {
            this.message = message;
        }
        public ApiError (string message, string detail) {
            this.message = message;
            this.detail = detail;
        }
    }
}