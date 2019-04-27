using System;
using System.Collections.Generic;
using System.Text;
using amoCRM.Library.Core.Objects;
using amoCRM.Library.Core.Objects.Private;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace amoCRM.Library.Responses.Private
{
    public class ResponseCurrentAccount : ApiResponse<CurrentAccount>
    {
    }

    public class CurrentAccount : ApiResult
    {
        [JsonProperty(PropertyName = "account")]
        public Account Account { get; set; }
    }
}
