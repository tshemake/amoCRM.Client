using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using amoCRM.Library.Core.Objects.Private;
using Newtonsoft.Json;

namespace amoCRM.Library.Responses.Private
{
    public class ResponseCompanies : ApiResponse<CompanyList>
    {
    }

    public class CompanyList : ApiResult
    {
        [JsonProperty(PropertyName = "companies")]
        public ReadOnlyCollection<Company> Companies { get; set; }
    }
}
