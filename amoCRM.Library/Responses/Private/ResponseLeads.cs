using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using amoCRM.Library.Core.Objects.Private;
using Newtonsoft.Json;

namespace amoCRM.Library.Responses.Private
{
    public class ResponseLeads : ApiResponse<LeadList>
    {
    }

    public class LeadList : ApiResult
    {
        [JsonProperty(PropertyName = "leads")]
        public ReadOnlyCollection<Lead> Leads { get; set; }
    }
}
