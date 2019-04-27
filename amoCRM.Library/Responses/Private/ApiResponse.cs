using System;
using System.Collections.Generic;
using System.Text;
using amoCRM.Library.Core.Objects;
using Newtonsoft.Json;

namespace amoCRM.Library.Responses.Private
{
    public class ApiResponse<TResult>
    {
        [JsonProperty(PropertyName = "response")]
        public TResult Response { get; set; }
    }
}
