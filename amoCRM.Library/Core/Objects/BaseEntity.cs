using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace amoCRM.Library.Core.Objects
{
    public abstract class BaseEntity<TKey> : IEntity<TKey>
    {
        [JsonProperty(PropertyName = "id")]
        public virtual TKey Id { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty(PropertyName = "created_at")]
        public virtual DateTime CreatedAt { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty(PropertyName = "updated_at")]
        public virtual DateTime UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "responsible_user_id")]
        public virtual int ResponsibleUserId { get; set; }
    }
}
