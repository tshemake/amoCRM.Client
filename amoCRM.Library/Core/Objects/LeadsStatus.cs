using System;
using System.Collections.Generic;
using System.Text;
using amoCRM.Library.Core.Types;
using Newtonsoft.Json;

namespace amoCRM.Library.Core.Objects
{
    public class LeadsStatus
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "pipeline_id")]
        public int PipeLineId { get; set; }

        [JsonProperty(PropertyName = "sort")]
        public int Sort { get; set; }

        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }

        [JsonProperty(PropertyName = "editable", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public YesNo? Editable { get; set; }
    }
}
