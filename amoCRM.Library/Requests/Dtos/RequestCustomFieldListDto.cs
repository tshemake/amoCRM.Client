using System;
using System.Collections.Generic;
using System.Text;
using amoCRM.Library.Core.Types;
using Newtonsoft.Json;

namespace amoCRM.Library.Requests.Dtos
{
    public class RequestCustomFieldListDto
    {
        /// <summary>
        /// Список добавляемых полей.
        /// </summary>
        [JsonProperty("add", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<RequestAddCustomFieldDto> AddedCustomFields { get; set; }

        /// <summary>
        /// Список полей для удаления.
        /// </summary>
        [JsonProperty("delete", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<RequestDeleteCustomFieldDto> DeletedCustomFields { get; set; }
    }
}
