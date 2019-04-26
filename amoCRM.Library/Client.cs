using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using amoCRM.Library.Core.Objects;
using amoCRM.Library.Helpers;
using amoCRM.Library.Requests;
using amoCRM.Library.Responses;
using Newtonsoft.Json;

namespace amoCRM.Library
{
    public class Client
    {
        public int ConnectionTimeout { get; set; } = 15000;
        public Dictionary<string, string> _defaultHeaders = new Dictionary<string, string>
        {
            { "Accept", "application/json;q=0.9,text/xml,application/xml,application/xhtml+xml;q=0.7" },
            { "Accept-Language", "en-us;q=0.8,en;q=0.5,ru-ru,ru;q=0.3" },
            { "Accept-Charset", "utf-8" },
        };
        public readonly string BaseAddress;
        public string UserAgent { get; set; } = "amoCRM-API-client/1.0";
        public Account Account { get; private set; }
        public HttpClient HttpClient { get; private set; }

        public Client(Account account)
        {
            Account = account;
            BaseAddress = string.Format(ApiConstants.API_URL, account.SubDomain);
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
            HttpClient = new HttpClient(handler) { BaseAddress = new Uri(BaseAddress) };
        }

        public async Task<Response<Core.Objects.Authorization>> AuthAsync() 
        {
            var requset = new RequestAuthorization(HttpClient, Account);
            return await requset.SendAsync();
        }

        public async Task<Response<Core.Objects.Account>> GetCurrentAccountAsync()
        {
            var requset = new RequestGetCurrentAccount(HttpClient);
            return await requset.SendAsync();
        }
    }
}
