using System;
using System.Collections.Generic;
using System.Text;
using amoCRM.Library.Core.Types;
using Newtonsoft.Json;

namespace amoCRM.Library.Core.Objects
{
    /// <summary>
    /// <see href="https://www.amocrm.ru/developers/content/api/account">Аккаунт</see>.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Уникальный идентификатор аккаунта.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Название аккаунта.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Уникальный субдомен данного аккаунта.
        /// </summary>
        [JsonProperty(PropertyName = "subdomain")]
        public string SubDomain { get; set; }

        /// <summary>
        /// Валюта аккаунта (используемая при работе с бюджетом сделок).
        /// </summary>
        /// <remarks>
        /// Не связано с биллинговой информацией самого аккаунта.
        /// </remarks>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Временная зона.
        /// </summary>
        [JsonProperty(PropertyName = "timezone")]
        public string TimeZone { get; set; }

        /// <summary>
        /// Cмещение временной зоны.
        /// </summary>
        [JsonProperty(PropertyName = "timezone_offset")]
        public string TimeZoneOffset { get; set; }

        /// <summary>
        /// Язык аккаунта.
        /// <list type="bullet">
        /// <item>
        /// <term>ru</term>
        /// <description>Русский.</description>
        /// </item>
        /// <item>
        /// <term>en</term>
        /// <description>Английский.</description>
        /// </item>
        /// </list>
        /// </summary>
        [JsonProperty(PropertyName = "language")]
        public Language Language { get; set; }
    }
}
