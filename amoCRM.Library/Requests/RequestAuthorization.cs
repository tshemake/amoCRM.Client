using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using amoCRM.Library.Core.Objects;
using amoCRM.Library.Exceptions;
using amoCRM.Library.Helpers;
using amoCRM.Library.Responses;

namespace amoCRM.Library.Requests
{
    public class RequestAuthorization : Request<Authorization>
    {
        private readonly HttpClient _httpClient;
        private readonly Account _account;

        public RequestAuthorization(HttpClient httpClient, Account account)
        {
            RequestUri = "/private/api/auth.php?type=json";
            _httpClient = httpClient;
            _account = account;
        }

        public override async Task<Response<Authorization>> SendAsync()
        {
            var api = new RequestApi();
            var response = await api.SendAsync<ResponseAuthorization>(_httpClient, RequestUri, GetContent(), GetHeaders());
            var result = new Response<Authorization>(response.Succeeded, response.Result.Authorization, response.Info);
            if (!response.Succeeded)
            {
                OnError(result);
            }
            return result;
        }

        public override void OnError(Response<Authorization> response)
        {
            if (response.Info.HttpStatusInfo.Code == System.Net.HttpStatusCode.Unauthorized)
            {
                var errorInfo = ErrorCodeList.Get(RequestType.Authorization, response.Info.ErrorCode, response.Info.HttpStatusInfo.Code);
                if (errorInfo != null)
                {
                    response.Info.Message = errorInfo.Message;
                }
            }
        }

        public override Dictionary<string, string> GetContent()
        {
            return new Dictionary<string, string>
                                 {
                                     { Constant.FORM_USER_LOGIN, _account.Login },
                                     { Constant.FORM_USER_HASH, _account.Hash },
                                 };
        }
    }
}
