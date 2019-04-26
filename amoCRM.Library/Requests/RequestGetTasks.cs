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
    public class RequestGetTasks : Request<ReadOnlyCollection<Core.Objects.Task>>
    {
        private readonly HttpClient _httpClient;

        public RequestGetTasks(HttpClient httpClient)
        {
            RequestUri = ApiConstants.GET_TASKS;
            _httpClient = httpClient;
        }

        public override async Task<Response<ReadOnlyCollection<Core.Objects.Task>>> SendAsync()
        {
            var api = new ApiRequest();
            var response = await api.SendAsync<ResponseTasks>(_httpClient, RequestUri, GetContent(), GetHeaders());
            var result = ProcessResponse(response);
            if (!result.Succeeded)
            {
                OnError(result);
            }
            return result;
        }

        private Response<ReadOnlyCollection<Core.Objects.Task>> ProcessResponse(Response<ResponseTasks> response)
        {
            Response<ReadOnlyCollection<Core.Objects.Task>> result;
            if (response.Succeeded)
            {
                result = new Response<ReadOnlyCollection<Core.Objects.Task>>(response.Succeeded, response.Result.Response.Tasks, response.Info);
            }
            if (response.Info.HttpStatusInfo.Code == System.Net.HttpStatusCode.NoContent)
            {
                result = new Response<ReadOnlyCollection<Core.Objects.Task>>(true, new List<Core.Objects.Task>().AsReadOnly(), response.Info);
            }
            else
            {
                result = new Response<ReadOnlyCollection<Core.Objects.Task>>(response.Succeeded, null, response.Info);
            }
            return result;
        }

        public override void OnError(Response<ReadOnlyCollection<Core.Objects.Task>> response)
        {
            var errorInfo = ErrorCodeList.Get(RequestType.Task, response.Info.ErrorCode);
            if (errorInfo != null)
            {
                response.Info.Message = errorInfo.Message;
            }
        }
    }
}
