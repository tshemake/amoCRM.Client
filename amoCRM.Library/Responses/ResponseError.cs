using System;
using System.Collections.Generic;
using System.Text;
using amoCRM.Library.Core.Objects;
using Newtonsoft.Json;

namespace amoCRM.Library.Responses
{
    public class ResponseError
    {
        [JsonProperty(PropertyName = "response")]
        public Error Error { get; set; }
    }
}
