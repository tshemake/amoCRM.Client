using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace amoCRM.Library.Core.Types
{
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum Method
    {
        Unknown = 0,

        [EnumMember(Value = "get")]
        Get,

        [EnumMember(Value = "post")]
        Post,

        [EnumMember(Value = "patch")]
        Patch,
    }
}
