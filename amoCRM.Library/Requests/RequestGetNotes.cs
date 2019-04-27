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
    public class RequestGetNotes : Request<ReadOnlyCollection<Note>>
    {
        public RequestGetNotes(HttpClient httpClient)
        {
            RequestUri = ApiConstants.API_GET_NOTES;
            RequestType = RequestType.Note;
            HttpClient = httpClient;
        }

        public async Task<Response<ReadOnlyCollection<Note>>> GetAsync(Core.Types.NoteType noteType)
        {
            BuildRequestUri(noteType);
            var response = await SendAsync();
            return new Response<ReadOnlyCollection<Note>>(response.Succeeded, response.Result, response.Info);
        }

        private void BuildRequestUri(Core.Types.NoteType noteType)
        {
            var queryParameter = new QueryParameter() { ModelType = ModelType.Note };
            switch (noteType)
            {
                case Core.Types.NoteType.Company:
                    queryParameter.Type = ModelType.Company;
                    break;
                case Core.Types.NoteType.Contact:
                    queryParameter.Type = ModelType.Contact;
                    break;
                case Core.Types.NoteType.Lead:
                    queryParameter.Type = ModelType.Lead;
                    break;
                case Core.Types.NoteType.Task:
                    queryParameter.Type = ModelType.Task;
                    break;
                default:
                    queryParameter.Type = ModelType.Unknown;
                    break;
            }
            RequestUri += ApiQuery.Get(queryParameter);
        }

        public override void OnError(Response<ReadOnlyCollection<Note>> response)
        {
            var errorInfo = ErrorCodeList.Get(RequestType, response.Info.ErrorCode);
            if (errorInfo != null)
            {
                response.Info.Message = errorInfo.Message;
            }
        }
    }
}
