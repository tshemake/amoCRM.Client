using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace amoCRM.Library.Core.Objects
{
    /// <summary>
    /// <see href="https://www.amocrm.ru/developers/content/api/leads">Сделки</see>.
    /// </summary>
    public class Lead
    {
        /// <summary>
        /// Уникальный идентификатор сделки.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Название сделки.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "created_by")]
        public int CreatedBy { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty(PropertyName = "updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "account_id")]
        public int AccountId { get; set; }

        [JsonProperty(PropertyName = "pipeline_id")]
        public int PipeLineId { get; set; }

        [JsonProperty(PropertyName = "status_id")]
        public int StatusId { get; set; }

        [JsonProperty(PropertyName = "is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty(PropertyName = "main_contact")]
        public Contact MainContact { get; set; }

        [JsonProperty(PropertyName = "group_id")]
        public int GroupId { get; set; }

        [JsonProperty(PropertyName = "company")]
        public Company Company { get; set; }

        [JsonProperty(PropertyName = "closed_at")]
        public int ClosedAt { get; set; }

        [JsonProperty(PropertyName = "closest_task_at")]
        public int ClosestTaskAt { get; set; }

        [JsonProperty(PropertyName = "sale")]
        public int Sale { get; set; }

        [JsonProperty(PropertyName = "loss_reason_id")]
        public int LossReasonId { get; set; }

        [JsonProperty(PropertyName = "contacts")]
        public ContactList Contacts { get; set; }

        [JsonProperty(PropertyName = "pipeline")]
        public PipeLine PipeLine { get; set; }

        [JsonProperty(PropertyName = "_links")]
        public Links Links { get; set; }
    }
}
