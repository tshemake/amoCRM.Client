using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using amoCRM.Library.Core.Objects;
using amoCRM.Library.Exceptions;
using amoCRM.Library.Helpers;
using amoCRM.Library.Responses;

namespace amoCRM.Library.Requests
{
    public class RequestGetLeads : Request<ReadOnlyCollection<Lead>>
    {
        public RequestGetLeads(HttpClient httpClient)
        {
            RequestUri = ApiConstants.API_GET_LEADS;
            RequestType = RequestType.Lead;
            HttpClient = httpClient;
        }

        public async Task<Response<ReadOnlyCollection<Lead>>> GetAsync()
        {
           var response = await SendAsync();
            return new Response<ReadOnlyCollection<Lead>>(response.Succeeded, response.Result, response.Info);
        }

        public override void OnError(Response<ReadOnlyCollection<Lead>> response)
        {
            var errorInfo = ErrorCodeList.Get(RequestType, response.Info.ErrorCode);
            if (errorInfo != null)
            {
                response.Info.Message = errorInfo.Message;
            }
        }
    }
}
