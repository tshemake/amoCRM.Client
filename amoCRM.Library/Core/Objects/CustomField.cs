using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using amoCRM.Library.Core.Types;
using Newtonsoft.Json;

namespace amoCRM.Library.Core.Objects
{
    public class CustomField
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

        [JsonProperty(PropertyName = "multiple")]
        public YesNo Multiple { get; set; }

        [JsonProperty(PropertyName = "type_id")]
        public string TypeId { get; set; }

        [JsonProperty(PropertyName = "disabled")]
        public string Disabled { get; set; }

        /// <summary>
        /// Порядковый номер при отображении (аналогично для сделок, компаний, покупателей).
        /// </summary>
        [JsonProperty(PropertyName = "sort")]
        public int Sort { get; set; }

        [JsonProperty(PropertyName = "is_required")]
        public bool IsRequired { get; set; }

        [JsonProperty(PropertyName = "is_deletable")]
        public bool IsDeletable { get; set; }

        [JsonProperty(PropertyName = "is_visible")]
        public bool IsVisible { get; set; }

        [JsonProperty(PropertyName = "values")]
        public ReadOnlyCollection<ValueField> Values { get; set; }
    }
}
