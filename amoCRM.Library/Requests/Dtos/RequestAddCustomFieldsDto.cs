using System;
using System.Collections.Generic;
using System.Text;
using amoCRM.Library.Core.Types;
using Newtonsoft.Json;

namespace amoCRM.Library.Requests.Dtos
{
    public class RequestAddCustomFieldsDto
    {
        /// <summary>
        /// Список добавляемых полей.
        /// </summary>
        [JsonProperty("add", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<RequestCustomFieldDto> CustomFields { get; set; }
    }
}
