using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using amoCRM.Library.Core.Objects;
using Newtonsoft.Json;

namespace amoCRM.Library.Responses
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
