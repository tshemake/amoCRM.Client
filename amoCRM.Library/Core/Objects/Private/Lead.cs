using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace amoCRM.Library.Core.Objects.Private
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

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty(PropertyName = "date_create")]
        public DateTime DateCreate { get; set; }

        [JsonProperty(PropertyName = "created_user_id")]
        public string CreatedUserId { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty(PropertyName = "last_modified")]
        public DateTime LastModified { get; set; }

        [JsonProperty(PropertyName = "account_id")]
        public string AccountId { get; set; }

        [JsonProperty(PropertyName = "price")]
        public string Price { get; set; }

        [JsonProperty(PropertyName = "responsible_user_id")]
        public string ResponsibleUserId { get; set; }

        [JsonProperty(PropertyName = "linked_company_id")]
        public string LinkedCompanyId { get; set; }

        [JsonProperty(PropertyName = "group_id")]
        public int GroupId { get; set; }

        [JsonProperty(PropertyName = "pipeline_id")]
        public int PipeLineId { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty(PropertyName = "date_close")]
        public DateTime DateClose { get; set; }

        [JsonProperty(PropertyName = "closest_task")]
        public int ClosestTask { get; set; }

        [JsonProperty(PropertyName = "loss_reason_id")]
        public int LossReasonId { get; set; }

        [JsonProperty(PropertyName = "deleted")]
        public int Deleted { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public ReadOnlyCollection<Tag> Tags { get; set; }

        [JsonProperty(PropertyName = "status_id")]
        public string StatusId { get; set; }

        [JsonProperty(PropertyName = "main_contact_id")]
        public object MainContactId { get; set; } // TODO: Может быть int и bool
    }
}
