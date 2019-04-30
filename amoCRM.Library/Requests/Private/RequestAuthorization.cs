using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using amoCRM.Library.Core.Objects;
using amoCRM.Library.Core.Objects.Private;
using amoCRM.Library.Exceptions;
using amoCRM.Library.Helpers;
using amoCRM.Library.Responses;

namespace amoCRM.Library.Requests.Private
{
    public class RequestAuthorization : Request<Authorization>
    {
        private string _userLogin;
        private string _userHash;

        public RequestAuthorization(HttpClient httpClient, ApiUri apiUri, string userLogin, string userHash)
        {
            RequestType = RequestType.Authorization;
            RequestUri = apiUri.Private.GetUrl(RequestType);
            HttpClient = httpClient;
            _userLogin = userLogin;
            _userHash = userHash;
        }

        public async Task<Response<Authorization>> GetAsync()
        {
            return await SendAsync();
        }

        public override void OnError(Response<Authorization> response)
        {
            if (response.Info.HttpStatusInfo.Code == System.Net.HttpStatusCode.Unauthorized)
            {
                var errorInfo = ErrorCodeList.Get(RequestType, response.Info.ErrorCode, response.Info.HttpStatusInfo.Code);
                if (errorInfo != null)
                {
                    response.Info.Message = errorInfo.Message;
                }
            }
        }

        public override HttpContent Serialize()
        {
            return new FormUrlEncodedContent(
                new Dictionary<string, string>
                {
                    { ApiConstants.FORM_USER_LOGIN, _userLogin },
                    { ApiConstants.FORM_USER_HASH, _userHash },
                });
        }
    }
}
