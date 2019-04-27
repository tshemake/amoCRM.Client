using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace amoCRM.Library.Core.Objects
{
    public class Embedded<TResult>
    {
        /// <summary>
        /// Массив, содержащий информацию по каждому отдельному элементу
        /// </summary>
        [JsonProperty(PropertyName = "items")]
        public TResult Items { get; set; }
    }
}
