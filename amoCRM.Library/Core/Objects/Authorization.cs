using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace amoCRM.Library.Core.Objects
{
    public class Authorization
    {
        [JsonProperty(PropertyName = "auth")]
        public bool Auth { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty(PropertyName = "server_time")]
        public DateTime ServerTime { get; set; }

        [JsonProperty(PropertyName = "accounts")]
        public ReadOnlyCollection<Account> Accounts { get; set; }

        [JsonProperty(PropertyName = "user")]
        public User User { get; set; }
    }
}
