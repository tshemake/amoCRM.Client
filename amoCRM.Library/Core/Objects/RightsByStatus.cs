using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace amoCRM.Library.Core.Objects
{
    public class RightsByStatus
    {
        [JsonProperty(PropertyName = "leads")]
        public object Leads { get; set; }
    }
}
