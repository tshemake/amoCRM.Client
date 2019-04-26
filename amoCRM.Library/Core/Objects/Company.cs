using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace amoCRM.Library.Core.Objects
{
    public class Company
    {
        /// <summary>
        /// Уникальный идентификатор компании.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Название компании.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty(PropertyName = "last_modified")]
        public DateTime LastModified { get; set; }

        [JsonProperty(PropertyName = "account_id")]
        public int AccountId { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty(PropertyName = "date_create")]
        public DateTime DateCreate { get; set; }

        [JsonProperty(PropertyName = "created_user_id")]
        public int CreatedUserId { get; set; }

        [JsonProperty(PropertyName = "modified_user_id")]
        public int ModifiedUserId { get; set; }

        [JsonProperty(PropertyName = "responsible_user_id")]
        public int ResponsibleUserId { get; set; }

        [JsonProperty(PropertyName = "group_id")]
        public int GroupId { get; set; }

        [JsonProperty(PropertyName = "closest_task")]
        public int ClosestTask { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public ReadOnlyCollection<Tag> Tags { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "custom_fields")]
        public ReadOnlyCollection<CustomField> CustomFields { get; set; }

        [JsonProperty(PropertyName = "linked_leads_id")]
        public ReadOnlyCollection<string> LinkedLeadsId { get; set; }
    }
}
