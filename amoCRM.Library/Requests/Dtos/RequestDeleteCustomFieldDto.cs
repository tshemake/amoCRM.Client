using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace amoCRM.Library.Requests.Dtos
{
    public class RequestDeleteCustomFieldDto
    {
        /// <summary>
        /// Уникальный идентификатор поля, который указывается с целью его удаления.
        /// </summary>
        [JsonProperty("id", Required = Required.Always)]
        public int Id { get; set; }

        /// <summary>
        /// Уникальный идентификатор сервиса по которому будет доступно удаление и изменение поля.
        /// </summary>
        [JsonProperty("origin", Required = Required.Always)]
        public string Origin { get; set; }
    }
}
