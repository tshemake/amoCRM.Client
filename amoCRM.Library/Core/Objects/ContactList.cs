using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Newtonsoft.Json;

namespace amoCRM.Library.Core.Objects
{
    public class ContactList
    {
        [JsonProperty(PropertyName = "id")]
        public ReadOnlyCollection<int> Id { get; set; }

        [JsonProperty(PropertyName = "_links")]
        public LinkList Links { get; set; }
    }
}
