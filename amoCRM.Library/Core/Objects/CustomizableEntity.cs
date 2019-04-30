using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using amoCRM.Library.Helpers.Converters;
using Newtonsoft.Json;

namespace amoCRM.Library.Core.Objects
{
    public abstract class CustomizableEntity : BaseEntity<int>
    {
        [JsonProperty(PropertyName = "custom_fields")]
        [JsonConverter(typeof(SingleOrArrayToArrayConverter<CustomField, int>))]
        public virtual ReadOnlyCollection<CustomField> CustomFields { get; set; }
    }
}
