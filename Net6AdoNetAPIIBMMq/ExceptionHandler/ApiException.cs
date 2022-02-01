using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ExceptionHandler
{
    [ExcludeFromCodeCoverage]
    public class ApiException : Exception
    {
        public int StatusCode { get; set; }

        public ApiException(string message,
                            int statusCode = 500) :
            base(message)
        {
            StatusCode = statusCode;
        }
        public ApiException(Exception ex, int statusCode = 500) : base(ex.Message)
        {
            StatusCode = statusCode;
        }
    }

    [ExcludeFromCodeCoverage]
    public class ApiError
    {
        public string message { get; set; }
        public bool isError { get; set; }
        public string detail { get; set; }

        public ApiError(string message)
        {
            this.message = message;
            isError = true;
        }

        //[ExcludeFromCodeCoverage]
        //public ApiError(ModelStateDictionary modelState)
        //{
        //    isError = true;
        //    if (modelState != null && modelState.Any(m => m.Value.Errors.Count > 0))
        //    {
        //        message = "Please correct the specified errors and try again.";
                
        //    }
        //}
    }
}
