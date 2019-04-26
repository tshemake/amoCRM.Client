using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using amoCRM.Library.Core.Objects;
using amoCRM.Library.Exceptions;
using amoCRM.Library.Helpers;
using amoCRM.Library.Responses;

namespace amoCRM.Library.Requests
{
    public class RequestGetCurrentAccount : Request<Core.Objects.Account>
    {
        private readonly HttpClient _httpClient;

        public RequestGetCurrentAccount(HttpClient httpClient)
        {
            RequestUri = ApiConstants.GET_CURRENT_ACCOUNT;
            _httpClient = httpClient;
        }

        public override async Task<Response<Core.Objects.Account>> SendAsync()
        {
            var api = new ApiRequest();
            var response = await api.SendAsync<ResponseCurrentAccount>(_httpClient, RequestUri, GetContent(), GetHeaders());
            var result = ProcessResponse(response);
            if (!result.Succeeded)
            { 
                OnError(result);
            }
            return result;
        }

        private Response<Core.Objects.Account> ProcessResponse(Response<ResponseCurrentAccount> response)
        {
            Response<Core.Objects.Account> result;
            if (response.Succeeded)
            {
                result = new Response<Core.Objects.Account>(response.Succeeded, response.Result.Response.Account, response.Info);
            }
            else
            {
                result = new Response<Core.Objects.Account>(response.Succeeded, null, response.Info);
            }
            return result;
        }
    }
}
