using System;
using System.Collections.Generic;
using System.Text;
using amoCRM.Library.Responses;

namespace amoCRM.Library.Exceptions
{
    public class ApiResponseException : Exception
    {
        public virtual HttpStatusInfo HttpStatus { get; }

        public ApiResponseException(string errorMessage)
            : base(errorMessage)
        {
        }

        public ApiResponseException(string errorMessage, HttpStatusInfo httpStatus)
            : base(errorMessage)
        {
            HttpStatus = httpStatus;
        }

        public ApiResponseException(string errorMessage, HttpStatusInfo httpStatus, Exception innerException)
            : base(errorMessage, innerException)
        {
            HttpStatus = httpStatus;
        }
    }
}
