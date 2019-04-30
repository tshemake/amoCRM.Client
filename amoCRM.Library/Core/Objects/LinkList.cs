using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace amoCRM.Library.Core.Objects
{
    public class LinkList
    {
        /// <summary>
        /// Массив содержащий информацию о текущем запросе.
        /// </summary>
        [JsonProperty(PropertyName = "self")]
        public Link Self { get; set; }

        [JsonProperty(PropertyName = "edit")]
        public Link Edit { get; set; }
    }
}
