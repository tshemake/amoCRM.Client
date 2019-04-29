using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace amoCRM.Library.Core.Types
{
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum CatalogType
    {
        Unknown = 0,

        /// <summary>
        /// Тип списка стандартный список.
        /// </summary>
        [EnumMember(Value = "regular")]
        Regular,

        /// <summary>
        /// Тип списка список счетов - в аккаунте может существовать только один список счетов.
        /// </summary>
        [EnumMember(Value = "invoices")]
        Invoices,
    }
}
