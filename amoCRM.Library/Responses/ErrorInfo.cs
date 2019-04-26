using System;
using System.Collections.Generic;
using System.Text;
using amoCRM.Library.Requests;

namespace amoCRM.Library.Responses
{
    public class ErrorInfo
    {
        public virtual string Code { get; set; }
        public virtual string Message { get; set; }
        public HttpStatusInfo HttpStatus { get; set; }
        public RequestType RequestType { get; set; }
    }
}
