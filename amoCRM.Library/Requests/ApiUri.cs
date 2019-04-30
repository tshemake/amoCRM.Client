using System;
using System.Collections.Generic;
using System.Text;
using amoCRM.Library.Helpers;

namespace amoCRM.Library.Requests
{
    public class ApiUri
    {
        public string BaseUrl { get; private set; }

        private readonly Dictionary<RequestType, string> _urls = new Dictionary<RequestType, string>();

        public PrivateApiUri Private { get; private set; }

        public ApiUri(string subDomain)
        {
            BaseUrl = string.Format(ApiConstants.API_URL, subDomain);

            _urls.Add(RequestType.Lead, "/api/v2/leads");
            _urls.Add(RequestType.Contact, "/api/v2/contacts");
            _urls.Add(RequestType.Company, "/api/v2/companies");
            _urls.Add(RequestType.ElementOfCatalog, "/api/v2/catalog_elements");
            _urls.Add(RequestType.IncomingLead, "/api/v2/incoming_leads");
            _urls.Add(RequestType.Task, "/api/v2/tasks");
            _urls.Add(RequestType.Note, "/api/v2/notes");
            _urls.Add(RequestType.Account, "/api/v2/account");
            _urls.Add(RequestType.CustomField, "/api/v2/fields");

            Private = new PrivateApiUri();
        }

        public string GetUrl(RequestType requestType)
        {
            return _urls[requestType];
        }
    }

    public class PrivateApiUri
    {
        private readonly Dictionary<RequestType, string> _urls = new Dictionary<RequestType, string>();

        public PrivateApiUri()
        {
            _urls.Add(RequestType.Authorization, "/private/api/auth.php?type=json");
            _urls.Add(RequestType.CurrentAccount, "/private/api/v2/json/accounts/current");
            _urls.Add(RequestType.Company, "/private/api/v2/json/companies");
            _urls.Add(RequestType.Lead, "/private/api/v2/json/leads");
            _urls.Add(RequestType.Task, "/private/api/v2/json/tasks");
            _urls.Add(RequestType.Contact, "/private/api/v2/json/contacts");
        }

        public string GetUrl(RequestType requestType)
        {
            return _urls[requestType];
        }
    }
}
