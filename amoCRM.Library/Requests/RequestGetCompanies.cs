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
    public class RequestGetCompanies : Request<ReadOnlyCollection<Company>>
    {
        public RequestGetCompanies(HttpClient httpClient, ApiUri apiUri)
        {
            RequestType = RequestType.Company;
            RequestUri = apiUri.GetUrl(RequestType);
            HttpClient = httpClient;
        }

        public async Task<Response<ReadOnlyCollection<Company>>> GetAsync()
        {
            var response = await SendAsync();
            return new Response<ReadOnlyCollection<Company>>(response.Succeeded, response.Result, response.Info);
        }

        public override void OnError(Response<ReadOnlyCollection<Company>> response)
        {
            var errorInfo = ErrorCodeList.Get(RequestType, response.Info.ErrorCode);
            if (errorInfo != null)
            {
                response.Info.Message = errorInfo.Message;
            }
        }
    }
}
