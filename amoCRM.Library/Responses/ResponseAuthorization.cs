using System;
using System.Collections.Generic;
using System.Text;
using amoCRM.Library.Core.Objects;
using Newtonsoft.Json;

namespace amoCRM.Library.Responses
{
    public class ResponseAuthorization
    {
        [JsonProperty(PropertyName = "response")]
        public Authorization Authorization { get; set; }
    }
}
