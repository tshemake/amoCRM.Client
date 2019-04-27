using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Newtonsoft.Json;

namespace amoCRM.Library.Core.Objects
{
    public class CustomerList
    {
        [JsonProperty(PropertyName = "id")]
        public ReadOnlyCollection<int> Id { get; set; }

        [JsonProperty(PropertyName = "_links")]
        public Links Links { get; set; }
    }
}
