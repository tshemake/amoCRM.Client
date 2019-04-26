using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace amoCRM.Library.Responses
{
    public class ResultInfo
    {
        public HttpStatusInfo HttpStatusInfo { get; }
        public string ErrorCode { get; }
        public string Message { get; set; }
        public Exception Exception { get; }

        public ResultInfo()
            : this(string.Empty)
        {
        }

        public ResultInfo(string errorCode)
        {
            ErrorCode = errorCode;
        }

        public ResultInfo(Exception exception)
        {
            Exception = exception;
        }

        public ResultInfo(HttpStatusInfo httpStatusInfo)
        {
            HttpStatusInfo = httpStatusInfo;
        }

        public ResultInfo(HttpStatusInfo httpStatusInfo, string errorCode)
            : this(httpStatusInfo)
        {
            ErrorCode = errorCode;
        }
    }
}
