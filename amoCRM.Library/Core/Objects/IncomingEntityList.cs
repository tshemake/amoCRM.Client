using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Newtonsoft.Json;

namespace amoCRM.Library.Core.Objects
{
    public class IncomingEntityList
    {
        [JsonProperty(PropertyName = "leads")]
        public ReadOnlyCollection<Lead> Leads { get; set; }

        [JsonProperty(PropertyName = "contacts")]
        public ReadOnlyCollection<Contact> Contacts { get; set; }
    }
}
