using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace amoCRM.Library.Responses
{
    public class HttpStatusInfo
    {
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
    }
}
