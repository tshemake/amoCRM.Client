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
    public class RequestGetCatalogs : Request<ReadOnlyCollection<Catalog>>
    {
        public RequestGetCatalogs(HttpClient httpClient, ApiUri apiUri)
        {
            RequestType = RequestType.Lead;
            RequestUri = apiUri.GetUrl(RequestType);
            HttpClient = httpClient;
        }

        public async Task<Response<ReadOnlyCollection<Catalog>>> GetAsync()
        {
           var response = await SendAsync();
            return new Response<ReadOnlyCollection<Catalog>>(response.Succeeded, response.Result, response.Info);
        }

        public override void OnError(Response<ReadOnlyCollection<Catalog>> response)
        {
            var errorInfo = ErrorCodeList.Get(RequestType, response.Info.ErrorCode);
            if (errorInfo != null)
            {
                response.Info.Message = errorInfo.Message;
            }
        }

        public override Response<ReadOnlyCollection<Catalog>> ProcessResponse(Response<ApiResponse<ReadOnlyCollection<Catalog>>> response)
        {
            Response<ReadOnlyCollection<Catalog>> result;
            if (response.Succeeded)
            {
                if (response.Result.Embedded == null)
                {
                    response.Result.Embedded = new Embedded<ReadOnlyCollection<Catalog>>
                    {
                        Items = new List<Catalog>().AsReadOnly()
                    };
                }
                result = new Response<ReadOnlyCollection<Catalog>>(response.Succeeded, response.Result.Embedded.Items, response.Info);
            }
            else
            {
                result = new Response<ReadOnlyCollection<Catalog>>(response.Succeeded, null, response.Info);
            }
            return result;
        }
    }
}
