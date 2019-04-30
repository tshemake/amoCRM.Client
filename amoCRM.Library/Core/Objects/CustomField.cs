using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using amoCRM.Library.Core.Types;
using Newtonsoft.Json;

namespace amoCRM.Library.Core.Objects
{
    public class CustomField : IEntity<int>
    {
        /// <summary>
        /// id дополнительного поля контакта (аналогично для сделок, компаний, покупателей).
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Имя дополнительного поля (аналогично для сделок, компаний, покупателей).
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "values")]
        public ReadOnlyCollection<ValueField> Values { get; set; }

        [JsonProperty(PropertyName = "is_system")]
        public bool IsSystem { get; set; }
    }
}
