using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace amoCRM.Library.Helpers
{
    public static class EntityEx
    {
        public static TResult GetAs<TResult>(string value)
        {
            return JsonConvert.DeserializeObject<TResult>(value);
        }
    }
}
