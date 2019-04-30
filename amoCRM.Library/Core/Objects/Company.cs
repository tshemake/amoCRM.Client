using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using amoCRM.Library.Helpers.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace amoCRM.Library.Core.Objects
{
    /// <summary>
    /// <see href="https://www.amocrm.ru/developers/content/api/companies">Компании</see>.
    /// </summary>
    public class Company : CustomizableEntity
    {
        /// <summary>
        /// Название компании.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "created_by")]
        public int CreatedBy { get; set; }

        [JsonProperty(PropertyName = "account_id")]
        public int AccountId { get; set; }

        [JsonProperty(PropertyName = "updated_by")]
        public int UpdatedBy { get; set; }

        [JsonProperty(PropertyName = "group_id")]
        public int GroupId { get; set; }

        [JsonProperty(PropertyName = "leads")]
        public LeadList Leads { get; set; }

        [JsonProperty(PropertyName = "closest_task_at")]
        public int ClosestTaskAt { get; set; }

        [JsonProperty(PropertyName = "tags")]
        [JsonConverter(typeof(SingleOrArrayToArrayConverter<Tag, int>))]
        public ReadOnlyCollection<Tag> Tags { get; set; }

        [JsonProperty(PropertyName = "contacts")]
        public ContactList Contacts { get; set; }

        [JsonProperty(PropertyName = "customers")]
        public CustomerList Customers { get; set; }

        [JsonProperty(PropertyName = "result")]
        public Result Result { get; set; }

        [JsonProperty(PropertyName = "_links")]
        public LinkList Links { get; set; }
    }
}
