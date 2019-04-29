using System;
using System.Collections.Generic;
using System.Text;
using amoCRM.Library.Core.Types;
using Newtonsoft.Json;

namespace amoCRM.Library.Core.Objects
{
    public class Catalog : CustomizableEntity<int>
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "can_add_elements")]
        public bool CanAddElements { get; set; }

        [JsonProperty(PropertyName = "can_show_in_cards")]
        public bool CanShowInCards { get; set; }

        [JsonProperty(PropertyName = "can_link_multiple")]
        public bool CanLinkMultiple { get; set; }

        [JsonProperty(PropertyName = "type")]
        public CatalogType? Type { get; set; }
    }
}
