using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using amoCRM.Library.Exceptions;
using amoCRM.Library.Responses;

namespace amoCRM.Library.Requests
{
    public abstract class Request<TResult>
    {
        public virtual string RequestUri { get; protected set; }

        public abstract Task<Response<TResult>> SendAsync();

        public virtual void OnError(Response<TResult> response)
        {
        }

        public virtual void ThrowIfHasException(Response<TResult> response)
        {
            if (response.Info.Exception != null)
            {
                throw new ApiResponseException(response.Info.Message, response.Info.HttpStatusInfo, response.Info.Exception);
            }
        }

        public virtual Dictionary<string, string> GetContent()
        {
            return new Dictionary<string, string>();
        }

        public virtual Dictionary<string, string> GetHeaders()
        {
            return new Dictionary<string, string>();
        }
    }
}
