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

        public const string FORM_USER_LOGIN = "USER_LOGIN";
        public const string FORM_USER_HASH = "USER_HASH";
    }
}
