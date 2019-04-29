using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using amoCRM.Library.Core.Objects;
using amoCRM.Library.Exceptions;
using amoCRM.Library.Responses;

namespace amoCRM.Library.Requests
{
    public abstract class Request<TResult> where TResult : class
    {
        public virtual string RequestUri { get; protected set; }
        public virtual HttpClient HttpClient { get; protected set; }
        public virtual RequestType RequestType { get; protected set; }

        public virtual async Task<Response<TResult>> SendAsync()
        {
            var api = new ApiRequest();
            var response = await api.SendAsync<ApiResponse<TResult>>(HttpClient, RequestUri, GetContent(), GetHeaders());
            var result = ProcessResponse(response);
            if (!result.Succeeded)
            {
                OnError(result);
            }
            return result;
        }

        public virtual Response<TResult> ProcessResponse(Response<ApiResponse<TResult>> response)
        {
            Response<TResult> result;
            if (response.Succeeded)
            {
                result = new Response<TResult>(response.Succeeded, response.Result.Embedded.Items, response.Info);
            }
            else
            {
                result = new Response<TResult>(response.Succeeded, null, response.Info);
            }
            return result;
        }

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
