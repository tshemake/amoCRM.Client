using System;
using System.Collections.Generic;
using System.Text;
using amoCRM.Library.Core.Objects;

namespace amoCRM.Library.Responses
{
    public class Response<TResult>
    {
        public Response(bool succeeded, TResult value, ResultInfo info)
        {
            Succeeded = succeeded;
            Result = value;
            Info = info;
        }

        public bool Succeeded { get; }

        public TResult Result { get; set; }

        public ResultInfo Info { get; } = new ResultInfo();
    }
}
