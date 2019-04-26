using System;
using System.Collections.Generic;
using System.Text;
using amoCRM.Library.Core.Objects;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace amoCRM.Library.Responses
{
    public class ResponseCurrentAccount : ApiResponse<CurrentAccount>
    {
    }

    public class CurrentAccount : ApiResult
    {
        [JsonProperty(PropertyName = "account")]
        public Core.Objects.Account Account { get; set; }
    }
}
