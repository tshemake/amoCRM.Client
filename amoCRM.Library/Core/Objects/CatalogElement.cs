
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace amoCRM.Library.Core.Objects
{
    /// <summary>
    /// Элемент каталога
    /// </summary>
    public class CatalogElement : CustomizableEntity<int>
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "catalog_id")]
        public int CatalogId { get; set; }

        [JsonProperty(PropertyName = "request_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? RequestId { get; set; }
    }
}
