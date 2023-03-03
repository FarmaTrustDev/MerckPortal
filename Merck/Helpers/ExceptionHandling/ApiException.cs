using System;

namespace Merck.Helpers.ExceptionHandling
{
    public class ApiException: Exception
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; }
        public int Code { get; set; }

        public new string InnerException { get; set; }
        public ApiException(string message = "Error", int code = 400)
          : base(message)
        {
            Success = false;
            Message = message;
            InnerException = message;
            Code = code;
        }
    }
}
