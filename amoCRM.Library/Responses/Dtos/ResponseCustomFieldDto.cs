using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using amoCRM.Library.Core.Objects;
using Newtonsoft.Json;

namespace amoCRM.Library.Responses.Dtos
{
    public class ResponseCustomFieldDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "_links")]
        public LinkList Links { get; set; }
    }
}
