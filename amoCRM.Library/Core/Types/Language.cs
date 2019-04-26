using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace amoCRM.Library.Core.Types
{
    [JsonConverter(typeof(StringEnumConverter), true)]
    public enum Language
    {
        Unknown = 0,

        /// <summary>
        /// Русский
        /// </summary>
        Ru,

        /// <summary>
        /// Английский
        /// </summary>
        En,
    }
}
