using System;
using System.Collections.Generic;
using System.Text;
using amoCRM.Library.Core.Objects;
using Newtonsoft.Json;

namespace amoCRM.Library.Responses
{
    public class ApiResponse<TResult>
    {
        /// <summary>
        /// Массив содержащий информацию о запросе.
        /// </summary>
        [JsonProperty(PropertyName = "_links")]
        public Links Links { get; set; }

        /// <summary>
        /// Массив содержащий информацию прилегающую к запросу.
        /// </summary>
        [JsonProperty(PropertyName = "_embedded")]
        public Embedded<TResult> Embedded { get; set; }
    }
}
