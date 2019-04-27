using System;
using System.Collections.Generic;
using System.Text;

namespace amoCRM.Library.Helpers
{
    public static class ApiConstants
    {
        public const string API_HOST = "{0}.amocrm.ru";
        public const string API_URL = "https://" + API_HOST;
        public const int MAX_LIMIT = 500;

        public const string API = "/api";
        public const string API_VERSION = "/v2";
        public const string API_VERSION_SUFFIX = API + API_VERSION;
        public const string PRIVATE_API_SUFFIX = "/private" + API;
        public const string PRIVATE_API_VERSION_SUFFIX = "/private" + API_VERSION_SUFFIX;

        public const string PRIVATE_API_AUTH = PRIVATE_API_SUFFIX + "/auth.php?type=json";
        public const string PRIVATE_API_GET_CURRENT_ACCOUNT = PRIVATE_API_VERSION_SUFFIX + "/json/accounts/current";
        public const string PRIVATE_API_GET_LEADS = PRIVATE_API_VERSION_SUFFIX + "/json/leads";
        public const string PRIVATE_API_GET_COMPANIES = PRIVATE_API_VERSION_SUFFIX + "/json/companies";
        public const string PRIVATE_API_GET_TASKS = PRIVATE_API_VERSION_SUFFIX + "/json/tasks";
        public const string PRIVATE_API_GET_CONTACTS = PRIVATE_API_VERSION_SUFFIX + "/json/contacts";

        public const string API_GET_LEADS = API_VERSION_SUFFIX + "/leads";
        public const string API_GET_COMPANIES = API_VERSION_SUFFIX + "/companies";
        public const string API_GET_TASKS = API_VERSION_SUFFIX + "/tasks";
        public const string API_GET_CONTACTS = API_VERSION_SUFFIX + "/contacts";
        public const string API_GET_NOTES = API_VERSION_SUFFIX + "/notes";
        public const string API_GET_INCOMING_LEADS = API_VERSION_SUFFIX + "/incoming_leads";

        public const string FORM_USER_LOGIN = "USER_LOGIN";
        public const string FORM_USER_HASH = "USER_HASH";
    }
}
