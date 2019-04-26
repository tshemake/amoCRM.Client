using System;
using System.Collections.Generic;
using System.Text;

namespace amoCRM.Library.Helpers
{
    public static class ApiConstants
    {
        public const string API_HOST = "{0}.amocrm.ru";
        public const string API_URL = "https://" + API_HOST;

        public const string API = "/api";
        public const string API_VERSION = "/v2";
        public const string PRIVATE_API_SUFFIX = "/private" + API;
        public const string PRIVATE_API_VERSION_SUFFIX = "/private" + API + API_VERSION;

        public const string AUTH = PRIVATE_API_SUFFIX + "/auth.php?type=json";
        public const string GET_CURRENT_ACCOUNT = PRIVATE_API_VERSION_SUFFIX + "/json/accounts/current";
        public const string GET_LEADS = PRIVATE_API_VERSION_SUFFIX + "/json/leads";
        public const string GET_COMPANIES = PRIVATE_API_VERSION_SUFFIX + "/json/companies";

        public const string FORM_USER_LOGIN = "USER_LOGIN";
        public const string FORM_USER_HASH = "USER_HASH";
    }
}
