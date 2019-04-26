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
            RequestUri = ApiConstants.AUTH;
            _httpClient = httpClient;
            _account = account;
        }

        public override async Task<Response<Authorization>> SendAsync()
        {
            var api = new ApiRequest();
            var response = await api.SendAsync<ResponseAuthorization>(_httpClient, RequestUri, GetContent(), GetHeaders());
            var result = ProcessResponse(response);
            if (!result.Succeeded)
            {
                OnError(result);
            }
            return result;
        }

        private Response<Authorization> ProcessResponse(Response<ResponseAuthorization> response)
        {
            Response<Authorization> result;
            if (response.Succeeded)
            {
                result = new Response<Authorization>(response.Succeeded, response.Result.Response, response.Info);
            }
            else
            {
                result = new Response<Authorization>(response.Succeeded, null, response.Info);
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
                                     { ApiConstants.FORM_USER_LOGIN, _account.Login },
                                     { ApiConstants.FORM_USER_HASH, _account.Hash },
                                 };
        }
    }
}
