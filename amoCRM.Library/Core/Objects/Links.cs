using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace amoCRM.Library.Core.Objects
{
    public class Links
    {
        /// <summary>
        /// Массив содержащий информацию о текущем запросе.
        /// </summary>
        [JsonProperty(PropertyName = "self")]
        public SelfLink Self { get; set; }
    }
}
