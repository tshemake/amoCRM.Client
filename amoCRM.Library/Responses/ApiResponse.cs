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
        /// Уникальный идентификатор новой сущности.
        /// </summary>
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? Id { get; set; }

        /// <summary>
        /// Уникальный идентификатор сущности в клиентской программе, если request_id не передан в запросе, то он генерируется автоматически.
        /// </summary>
        [JsonProperty("request_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? RequestId { get; set; }

        /// <summary>
        /// Массив содержащий информацию о запросе.
        /// </summary>
        [JsonProperty(PropertyName = "_links")]
        public LinkList Links { get; set; }

        /// <summary>
        /// Массив содержащий информацию прилегающую к запросу.
        /// </summary>
        [JsonProperty(PropertyName = "_embedded")]
        public Embedded<TResult> Embedded { get; set; }
    }
}
