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
using amoCRM.Library.Responses.Private;

namespace amoCRM.Library.Requests.Private
{
    public class RequestGetTasks : Request<TaskList>
    {
        public RequestGetTasks(HttpClient httpClient, ApiUri apiUri)
        {
            RequestType = RequestType.Task;
            RequestUri = apiUri.Private.GetUrl(RequestType);
            HttpClient = httpClient;
        }

        public async Task<Response<ReadOnlyCollection<Core.Objects.Private.Task>>> GetAsync()
        {
            var response = await SendAsync();
            return new Response<ReadOnlyCollection<Core.Objects.Private.Task>>(response.Succeeded, response.Result.Tasks, response.Info);
        }

        public override Response<TaskList> ProcessResponse(Response<Responses.Private.ApiResponse<TaskList>> response)
        {
            Response<TaskList> result;
            if (response.Succeeded)
            {
                result = new Response<TaskList>(response.Succeeded, response.Result.Response, response.Info);
            }
            else if (response.Info.HttpStatusInfo.Code == System.Net.HttpStatusCode.NoContent)
            {
                result = new Response<TaskList>(true, new TaskList { Tasks = new List<Core.Objects.Private.Task>().AsReadOnly() }, response.Info);
            }
            else
            {
                result = new Response<TaskList>(response.Succeeded, new TaskList { Tasks = null }, response.Info);
            }
            return result;
        }

        public override void OnError(Response<TaskList> response)
        {
            var errorInfo = ErrorCodeList.Get(RequestType.Task, response.Info.ErrorCode);
            if (errorInfo != null)
            {
                response.Info.Message = errorInfo.Message;
            }
        }
    }
}
