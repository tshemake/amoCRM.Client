using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using amoCRM.Library.Core.Objects;
using amoCRM.Library.Helpers;
using amoCRM.Library.Requests;
using amoCRM.Library.Requests.Dtos;
using amoCRM.Library.Responses;
using amoCRM.Library.Responses.Dtos;

namespace amoCRM.Library
{
    public class Client
    {
        private readonly ApiUri _apiUri;
        public string UserLogin { get; private set; }
        public string UserHash { get; private set; }
        public HttpClient HttpClient { get; private set; }

        private Client(ApiUri apiUri)
        {
            _apiUri = apiUri;
        }

        public static Client BuildClient(string subDomain)
        {
            var apiUri = new ApiUri(subDomain);
            IHttpSettings settings = new HttpSettings()
            {
                BaseUrl = apiUri.BaseUrl,
                UserAgent = $"({GetASPNetVersion()}; {GetOsVersion()}; {GetArchitecture()})"
            };
            var client = new Client(apiUri)
            {
                HttpClient = HttpClientFactory.Instance.GetClient(settings)
            };

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
            var request = new Requests.Private.RequestAuthorization(HttpClient, _apiUri, UserLogin, UserHash);
            return await request.GetAsync();
        }

        public async Task<Response<Core.Objects.Private.Account>> GetCurrentAccountPrivateApiAsync()
        {
            var request = new Requests.Private.RequestGetCurrentAccount(HttpClient, _apiUri);
            return await request.GetAsync();
        }

        public async Task<Response<ReadOnlyCollection<Core.Objects.Private.Lead>>> GetLeadsPrivateApiAsync()
        {
            var request = new Requests.Private.RequestGetLeads(HttpClient, _apiUri);
            return await request.GetAsync();
        }

        public async Task<Response<ReadOnlyCollection<Lead>>> GetLeadsAsync()
        {
            var request = new RequestGetLeads(HttpClient, _apiUri);
            return await request.GetAsync();
        }

        public async Task<Response<ReadOnlyCollection<Core.Objects.Private.Company>>> GetCompaniesPrivateApiAsync()
        {
            var request = new Requests.Private.RequestGetCompanies(HttpClient, _apiUri);
            return await request.GetAsync();
        }

        public async Task<Response<ReadOnlyCollection<Company>>> GetCompaniesAsync()
        {
            var request = new RequestGetCompanies(HttpClient, _apiUri);
            return await request.GetAsync();
        }

        public async Task<Response<ReadOnlyCollection<Core.Objects.Private.Task>>> GetTasksPrivateApiAsync()
        {
            var request = new Requests.Private.RequestGetTasks(HttpClient, _apiUri);
            return await request.GetAsync();
        }

        public async Task<Response<ReadOnlyCollection<Core.Objects.Task>>> GetTasksAsync()
        {
            var request = new RequestGetTasks(HttpClient, _apiUri);
            return await request.GetAsync();
        }

        public async Task<Response<ReadOnlyCollection<Core.Objects.Private.Contact>>> GetContactsPrivateApiAsync()
        {
            var request = new Requests.Private.RequestGetContacts(HttpClient, _apiUri);
            return await request.GetAsync();
        }

        public async Task<Response<ReadOnlyCollection<Contact>>> GetContactsAsync()
        {
            var request = new RequestGetContacts(HttpClient, _apiUri);
            return await request.GetAsync();
        }

        public async Task<Response<ReadOnlyCollection<Note>>> GetNotesAsync(Core.Types.NoteType noteType)
        {
            var request = new RequestGetNotes(HttpClient, _apiUri);
            return await request.GetAsync(noteType);
        }

        public async Task<Response<ReadOnlyCollection<IncomingLead>>> GetIncomingLeadsAsync()
        {
            var request = new RequestGetIncomingLeads(HttpClient, _apiUri);
            return await request.GetAsync();
        }

        public async Task<Response<ReadOnlyCollection<CatalogElement>>> GetCatalogElementsAsync()
        {
            var request = new RequestGetCatalogElements(HttpClient, _apiUri);
            return await request.GetAsync();
        }

        public async Task<Response<ReadOnlyCollection<Catalog>>> GetCatalogsAsync()
        {
            var request = new RequestGetCatalogs(HttpClient, _apiUri);
            return await request.GetAsync();
        }

        public async Task<Response<ReadOnlyCollection<ResponseCustomFieldDto>>> AddCustomFieldsAsync(IEnumerable<RequestAddCustomFieldDto> fields)
        {
            var request = new RequestAddCustomFields(HttpClient, _apiUri);
            return await request.PostAsync(fields);
        }

        public async Task<Response<ReadOnlyCollection<ResponseCustomFieldDto>>> DeleteCustomFieldsAsync(IEnumerable<RequestDeleteCustomFieldDto> fields)
        {
            var request = new RequestDeleteCustomFields(HttpClient, _apiUri);
            return await request.PostAsync(fields);
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
