using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace amoCRM.Library.Core.Types
{
    public enum YesNo
    {
        Unknown = 0,

        [EnumMember(Value = "Y")]
        Yes,

        [EnumMember(Value = "N")]
        No,
    }
}
