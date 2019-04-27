using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace amoCRM.Library.Core.Objects
{
    /// <summary>
    /// <see href="https://www.amocrm.ru/developers/content/api/unsorted">Неразобранное</see>.
    /// </summary>
    public class IncomingLead
    {
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "uid")]
        public string Uid { get; set; }

        [JsonProperty(PropertyName = "source_name")]
        public string SourceName { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "source_uid")]
        public string SourceUid { get; set; }

        //[JsonProperty(PropertyName = "incoming_lead_info")]
        //public IncomingLeadInfo IncomingLeadInfo { get; set; }

        //[JsonProperty(PropertyName = "incoming_entities")]
        //public IncomingEntityList IncomingEntities { get; set; }

    }
}
