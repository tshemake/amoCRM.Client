using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using amoCRM.Library.Core.Objects.Private;
using amoCRM.Library.Exceptions;
using amoCRM.Library.Helpers;
using amoCRM.Library.Responses;
using amoCRM.Library.Responses.Private;

namespace amoCRM.Library.Requests.Private
{
    public class RequestGetCurrentAccount : Request<CurrentAccount>
    {
        public RequestGetCurrentAccount(HttpClient httpClient, ApiUri apiUri)
        {
            RequestType = RequestType.CurrentAccount;
            RequestUri = apiUri.Private.GetUrl(RequestType);
            HttpClient = httpClient;
        }

        public async Task<Response<Account>> GetAsync()
        {
            var response = await SendAsync();
            return new Response<Account>(response.Succeeded, response.Result.Account, response.Info);
        }
    }
}
