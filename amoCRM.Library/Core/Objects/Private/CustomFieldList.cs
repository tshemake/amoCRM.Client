using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Newtonsoft.Json;

namespace amoCRM.Library.Core.Objects.Private
{
    public class CustomFieldList
    {
        /// <summary>
        /// Дополнительные поля контактов.
        /// </summary>
        [JsonProperty(PropertyName = "contacts")]
        public ReadOnlyCollection<CustomField> ContactCustomFields { get; set; }

        /// <summary>
        /// Дополнительные поля сделок.
        /// </summary>
        [JsonProperty(PropertyName = "leads")]
        public ReadOnlyCollection<CustomField> LeadCustomFields { get; set; }

        /// <summary>
        /// Дополнительные поля компаний.
        /// </summary>
        [JsonProperty(PropertyName = "companies")]
        public ReadOnlyCollection<CustomField> CompanyCustomFields { get; set; }

        /// <summary>
        /// Дополнительные поля покупателей.
        /// </summary>
        [JsonProperty(PropertyName = "customers")]
        public ReadOnlyCollection<CustomField> CustomerCustomFields { get; set; }
    }
}
