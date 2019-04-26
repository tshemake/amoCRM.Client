using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace amoCRM.Library.Core.Objects
{
    public class Task
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "element_id")]
        public string ElementId { get; set; }

        [JsonProperty(PropertyName = "element_type")]
        public string ElementType { get; set; }

        [JsonProperty(PropertyName = "task_type")]
        public string TaskType { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty(PropertyName = "date_create")]
        public DateTime DateCreate { get; set; }

        [JsonProperty(PropertyName = "created_user_id")]
        public string CreatedUserId { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty(PropertyName = "last_modified")]
        public DateTime LastModified { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "responsible_user_id")]
        public string ResponsibleUserId { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty(PropertyName = "complete_till")]
        public DateTime CompleteTill { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "group_id")]
        public int GroupId { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = "account_id")]
        public string AccountId { get; set; }

        [JsonProperty(PropertyName = "result")]
        public object Result { get; set; }
    }
}
