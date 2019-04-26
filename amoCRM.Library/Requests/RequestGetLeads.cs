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
        private readonly HttpClient _httpClient;

        public RequestGetLeads(HttpClient httpClient)
        {
            RequestUri = ApiConstants.GET_LEADS;
            _httpClient = httpClient;
        }

        public override async Task<Response<ReadOnlyCollection<Lead>>> SendAsync()
        {
            var api = new ApiRequest();
            var response = await api.SendAsync<ResponseLeads>(_httpClient, RequestUri, GetContent(), GetHeaders());
            Response<ReadOnlyCollection<Lead>> result;
            if (response.Succeeded)
            {
                result = new Response<ReadOnlyCollection<Lead>>(response.Succeeded, response.Result.Response.Leads, response.Info);
            }
            else
            {
                result = new Response<ReadOnlyCollection<Lead>>(response.Succeeded, null, response.Info);
                OnError(result);
            }
            return result;
        }

        public override void OnError(Response<ReadOnlyCollection<Lead>> response)
        {
            var errorInfo = ErrorCodeList.Get(RequestType.Lead, response.Info.ErrorCode);
            if (errorInfo != null)
            {
                response.Info.Message = errorInfo.Message;
            }
        }
    }
}
