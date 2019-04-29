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
    public class RequestGetCatalogElements : Request<ReadOnlyCollection<CatalogElement>>
    {
        public RequestGetCatalogElements(HttpClient httpClient)
        {
            RequestUri = ApiConstants.API_GET_CATALOG_ELEMENTS;
            RequestType = RequestType.Lead;
            HttpClient = httpClient;
        }

        public async Task<Response<ReadOnlyCollection<CatalogElement>>> GetAsync()
        {
           var response = await SendAsync();
            return new Response<ReadOnlyCollection<CatalogElement>>(response.Succeeded, response.Result, response.Info);
        }

        public override void OnError(Response<ReadOnlyCollection<CatalogElement>> response)
        {
            var errorInfo = ErrorCodeList.Get(RequestType, response.Info.ErrorCode);
            if (errorInfo != null)
            {
                response.Info.Message = errorInfo.Message;
            }
        }

        public override Response<ReadOnlyCollection<CatalogElement>> ProcessResponse(Response<ApiResponse<ReadOnlyCollection<CatalogElement>>> response)
        {
            Response<ReadOnlyCollection<CatalogElement>> result;
            if (response.Succeeded)
            {
                if (response.Result.Embedded == null)
                {
                    response.Result.Embedded = new Embedded<ReadOnlyCollection<CatalogElement>>
                    {
                        Items = new List<CatalogElement>().AsReadOnly()
                    };
                }
                result = new Response<ReadOnlyCollection<CatalogElement>>(response.Succeeded, response.Result.Embedded.Items, response.Info);
            }
            else
            {
                result = new Response<ReadOnlyCollection<CatalogElement>>(response.Succeeded, null, response.Info);
            }
            return result;
        }
    }
}
