using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace amoCRM.Library.Core.Objects
{
    public class Error
    {
        [JsonProperty(PropertyName = "domain")]
        public string Domain { get; set; }

        [JsonProperty(PropertyName = "auth")]
        public bool Auth { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty(PropertyName = "server_time")]
        public DateTime ServerTime { get; set; }

        [JsonProperty(PropertyName = "error")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "error_code")]
        public string Code { get; set; }
    }
}
