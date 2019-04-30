using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class RequestGetCompanies : Request<CompanyList>
    {
        public RequestGetCompanies(HttpClient httpClient, ApiUri apiUri)
        {
            RequestType = RequestType.Company;
            RequestUri = apiUri.Private.GetUrl(RequestType);
            HttpClient = httpClient;
        }

        public async Task<Response<ReadOnlyCollection<Company>>> GetAsync()
        {
            var response = await SendAsync();
            return new Response<ReadOnlyCollection<Company>>(response.Succeeded, response.Result.Companies, response.Info);
        }
    }
}
