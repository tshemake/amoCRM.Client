using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using amoCRM.Library.Core.Objects.Private;
using Newtonsoft.Json;

namespace amoCRM.Library.Responses.Private
{
    public class ResponseContacts : ApiResponse<ContactList>
    {
    }

    public class ContactList : ApiResult
    {
        [JsonProperty(PropertyName = "contacts")]
        public ReadOnlyCollection<Contact> Contacts { get; set; }
    }
}
