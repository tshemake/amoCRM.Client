using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Versioning;
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
        public string BaseAddress { get; private set; }
        public string UserLogin { get; private set; }
        public string UserHash { get; private set; }
        public HttpClient HttpClient { get; private set; }

        private Client() { }

        public static Client BuildClient(string subDomain)
        {
            var client = new Client
            {
                BaseAddress = string.Format(ApiConstants.API_URL, subDomain)
            };
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
            client.HttpClient = new HttpClient(handler) { BaseAddress = new Uri(client.BaseAddress) };
            client.HttpClient.DefaultRequestHeaders.UserAgent.ParseAdd($"({GetASPNetVersion()}; {GetOsVersion()}; {GetArchitecture()})");

            return client;
        }

        public Client SetAccount(string userLogin, string userHash)
        {
            UserLogin = userLogin;
            UserHash = userHash;

            return this;
        }

        public async Task<Response<Core.Objects.Private.Authorization>> AuthPrivateApiAsync() 
        {
            var request = new Requests.Private.RequestAuthorization(HttpClient, UserLogin, UserHash);
            return await request.GetAsync();
        }

        public async Task<Response<Core.Objects.Private.Account>> GetCurrentAccountPrivateApiAsync()
        {
            var request = new Requests.Private.RequestGetCurrentAccount(HttpClient);
            return await request.GetAsync();
        }

        public async Task<Response<ReadOnlyCollection<Core.Objects.Private.Lead>>> GetLeadsPrivateApiAsync()
        {
            var request = new Requests.Private.RequestGetLeads(HttpClient);
            return await request.GetAsync();
        }

        public async Task<Response<ReadOnlyCollection<Lead>>> GetLeadsAsync()
        {
            var request = new RequestGetLeads(HttpClient);
            return await request.GetAsync();
        }

        public async Task<Response<ReadOnlyCollection<Core.Objects.Private.Company>>> GetCompaniesPrivateApiAsync()
        {
            var request = new Requests.Private.RequestGetCompanies(HttpClient);
            return await request.GetAsync();
        }

        public async Task<Response<ReadOnlyCollection<Company>>> GetCompaniesAsync()
        {
            var request = new RequestGetCompanies(HttpClient);
            return await request.GetAsync();
        }

        public async Task<Response<ReadOnlyCollection<Core.Objects.Private.Task>>> GetTasksPrivateApiAsync()
        {
            var request = new Requests.Private.RequestGetTasks(HttpClient);
            return await request.GetAsync();
        }

        public async Task<Response<ReadOnlyCollection<Core.Objects.Task>>> GetTasksAsync()
        {
            var request = new RequestGetTasks(HttpClient);
            return await request.GetAsync();
        }

        public async Task<Response<ReadOnlyCollection<Core.Objects.Private.Contact>>> GetContactsPrivateApiAsync()
        {
            var request = new Requests.Private.RequestGetContacts(HttpClient);
            return await request.GetAsync();
        }

        public async Task<Response<ReadOnlyCollection<Contact>>> GetContactsAsync()
        {
            var request = new RequestGetContacts(HttpClient);
            return await request.GetAsync();
        }

        public async Task<Response<ReadOnlyCollection<Note>>> GetNotesAsync(Core.Types.NoteType noteType)
        {
            var request = new RequestGetNotes(HttpClient);
            return await request.GetAsync(noteType);
        }

        public async Task<Response<ReadOnlyCollection<IncomingLead>>> GetIncomingLeadsAsync()
        {
            var request = new RequestGetIncomingLeads(HttpClient);
            return await request.GetAsync();
        }

        public async Task<Response<ReadOnlyCollection<CatalogElement>>> GetCatalogElementsAsync()
        {
            var request = new RequestGetCatalogElements(HttpClient);
            return await request.GetAsync();
        }

        public async Task<Response<ReadOnlyCollection<Catalog>>> GetCatalogsAsync()
        {
            var request = new RequestGetCatalogs(HttpClient);
            return await request.GetAsync();
        }

        public static string GetOsVersion()
        {
            return System.Runtime.InteropServices.RuntimeInformation.OSDescription;
        }

        public static string GetArchitecture()
        {
            return System.Runtime.InteropServices.RuntimeInformation.OSArchitecture.ToString();
        }

        public static string GetASPNetVersion()
        {
            return Assembly
                    .GetEntryAssembly()?
                    .GetCustomAttribute<TargetFrameworkAttribute>()?
                    .FrameworkName;
        }

        public string GetClientVersion()
        {
            return GetType()
                .GetTypeInfo()
                .Assembly
                .GetName()
                .Version
                .ToString();
        }
    }
}
