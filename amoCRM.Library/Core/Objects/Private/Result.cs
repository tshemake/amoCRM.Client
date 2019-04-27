using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace amoCRM.Library.Core.Objects.Private
{
    public class Result
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}
