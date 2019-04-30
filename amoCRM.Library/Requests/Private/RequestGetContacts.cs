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
    public class RequestGetContacts : Request<ContactList>
    {
        public RequestGetContacts(HttpClient httpClient, ApiUri apiUri)
        {
            RequestType = RequestType.Contact;
            RequestUri = apiUri.Private.GetUrl(RequestType);
            HttpClient = httpClient;
        }

        public async Task<Response<ReadOnlyCollection<Contact>>> GetAsync()
        {
            var response = await SendAsync();
            return new Response<ReadOnlyCollection<Contact>>(response.Succeeded, response.Result.Contacts, response.Info);
        }

        public override void OnError(Response<ContactList> response)
        {
            var errorInfo = ErrorCodeList.Get(RequestType, response.Info.ErrorCode);
            if (errorInfo != null)
            {
                response.Info.Message = errorInfo.Message;
            }
        }
    }
}
