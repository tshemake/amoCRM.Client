using System;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace amoCRM.Library.Core.Objects
{
    /// <summary>
    /// <see href="https://www.amocrm.ru/developers/content/api/contacts">Контакты</see>.
    /// </summary>
    public class Contact : CustomizableEntity<int>
    {
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

        [JsonProperty(PropertyName = "company")]
        public Company Company { get; set; }

        [JsonProperty(PropertyName = "leads")]
        public LeadList Leads { get; set; }

        [JsonProperty(PropertyName = "closest_task_at")]
        public int ClosestTaskAt { get; set; }

        [JsonProperty(PropertyName = "customers")]
        public CustomerList Customers { get; set; }

        [JsonProperty(PropertyName = "_links")]
        public Links Links { get; set; }
    }
}
