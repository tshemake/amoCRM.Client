using System;
using System.Collections.Generic;
using System.Text;
using amoCRM.Library.Core.Types;
using Newtonsoft.Json;

namespace amoCRM.Library.Core.Objects
{
    public class Link
    {
        /// <summary>
        /// Относительный URL текущего запроса
        /// </summary>
        [JsonProperty(PropertyName = "href")]
        public string Href { get; set; }

        /// <summary>
        /// Метод текущего запроса
        /// </summary>
        [JsonProperty(PropertyName = "method")]
        public Method Method { get; set; }
    }
}
