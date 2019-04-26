using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace amoCRM.Library.Core.Objects
{
    public class AmojoRights
    {
        [JsonProperty(PropertyName = "can_direct")]
        public bool CanDirect { get; set; }

        [JsonProperty(PropertyName = "can_group_create")]
        public bool CanGroupCreate { get; set; }
    }
}
