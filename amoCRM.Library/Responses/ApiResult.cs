using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace amoCRM.Library.Responses
{
    public abstract class ApiResult
    {
        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty(PropertyName = "server_time")]
        public virtual DateTime ServerTime { get; set; }
    }
}
