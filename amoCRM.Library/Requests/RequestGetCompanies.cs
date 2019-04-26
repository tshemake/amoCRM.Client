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
        private readonly HttpClient _httpClient;

        public RequestGetCompanies(HttpClient httpClient)
        {
            RequestUri = ApiConstants.GET_COMPANIES;
            _httpClient = httpClient;
        }

        public override async Task<Response<ReadOnlyCollection<Company>>> SendAsync()
        {
            var api = new ApiRequest();
            var response = await api.SendAsync<ResponseCompanies>(_httpClient, RequestUri, GetContent(), GetHeaders());
            Response<ReadOnlyCollection<Company>> result;
            if (response.Succeeded)
            {
                result = new Response<ReadOnlyCollection<Company>>(response.Succeeded, response.Result.Response.Companies, response.Info);
            }
            else
            {
                result = new Response<ReadOnlyCollection<Company>>(response.Succeeded, null, response.Info);
                OnError(result);
            }
            return result;
        }
    }
}
