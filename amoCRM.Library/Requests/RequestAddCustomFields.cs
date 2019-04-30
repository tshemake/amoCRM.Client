using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using amoCRM.Library.Core.Objects;
using amoCRM.Library.Exceptions;
using amoCRM.Library.Helpers;
using amoCRM.Library.Requests.Dtos;
using amoCRM.Library.Responses;
using amoCRM.Library.Responses.Dtos;
using Newtonsoft.Json;

namespace amoCRM.Library.Requests
{
    public class RequestAddCustomFields : Request<ReadOnlyCollection<ResponseCustomFieldDto>>
    {
        private IEnumerable<RequestCustomFieldDto> _fields;

        public RequestAddCustomFields(HttpClient httpClient, ApiUri apiUri)
        {
            RequestType = RequestType.CustomField;
            RequestUri = apiUri.GetUrl(RequestType);
            HttpClient = httpClient;
        }

        public async Task<Response<ReadOnlyCollection<ResponseCustomFieldDto>>> PostAsync(IEnumerable<RequestCustomFieldDto> fields)
        {
            _fields = fields;
            var response = await SendAsync();
            return new Response<ReadOnlyCollection<ResponseCustomFieldDto>>(response.Succeeded, response.Result, response.Info);
        }

        public override void OnError(Response<ReadOnlyCollection<ResponseCustomFieldDto>> response)
        {
            var errorInfo = ErrorCodeList.Get(RequestType, response.Info.ErrorCode);
            if (errorInfo != null)
            {
                response.Info.Message = errorInfo.Message;
            }
        }

        public override HttpContent Serialize()
        {
            return new StringContent(JsonConvert.SerializeObject(new RequestAddCustomFieldsDto
            {
                CustomFields = _fields
            }), Encoding.UTF8, "application/json");
        }
    }
}
