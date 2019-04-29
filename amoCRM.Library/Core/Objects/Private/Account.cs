using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using amoCRM.Library.Core.Types;
using Newtonsoft.Json;

namespace amoCRM.Library.Core.Objects.Private
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
        public string Id { get; set; }

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
        [JsonProperty(PropertyName = "language", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Language? Language { get; set; }

        [JsonProperty(PropertyName = "notifications_base_url")]
        public string NotificationsBaseUrl { get; set; }

        [JsonProperty(PropertyName = "notifications_ws_url")]
        public string NotificationsWsUrl { get; set; }

        [JsonProperty(PropertyName = "notifications_ws_url_v2")]
        public string NotificationsWsUrlV2 { get; set; }

        [JsonProperty(PropertyName = "amojo_base_url")]
        public string AmojoBaseUrl { get; set; }

        [JsonProperty(PropertyName = "amojo_rights")]
        public AmojoRights AmojoRights { get; set; }

        /// <summary>
        /// id текущего пользователя.
        /// </summary>
        [JsonProperty(PropertyName = "current_user")]
        public int CurrentUser { get; set; }

        [JsonProperty(PropertyName = "version")]
        public int Version { get; set; }

        /// <summary>
        /// Формат даты. (описание формата см. <see href="https://www.amocrm.ru/developers/content/api/account#date">здесь</see>)
        /// </summary>
        [JsonProperty(PropertyName = "date_pattern")]
        public string DatePattern { get; set; }

        [JsonProperty(PropertyName = "short_date_pattern")]
        public ShortDatePattern ShortDatePattern { get; set; }

        [JsonProperty(PropertyName = "date_format")]
        public string DateFormat { get; set; }

        [JsonProperty(PropertyName = "time_format")]
        public string TimeFormat { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "unsorted_on")]
        public YesNo? UnsortedOn { get; set; }

        [JsonProperty(PropertyName = "mobile_feature_version")]
        public int MobileFeatureVersion { get; set; }

        [JsonProperty(PropertyName = "loss_reasons_enabled")]
        public bool LossReasonsEnabled { get; set; }

        [JsonProperty(PropertyName = "helpbot_enabled")]
        public bool HelpbotEnabled { get; set; }

        [JsonProperty(PropertyName = "users")]
        public ReadOnlyCollection<User> Users { get; set; }

        [JsonProperty(PropertyName = "groups")]
        public ReadOnlyCollection<Group> Groups { get; set; }

        [JsonProperty(PropertyName = "leads_statuses")]
        public ReadOnlyCollection<LeadsStatus> LeadsStatuses { get; set; }

        [JsonProperty(PropertyName = "custom_fields")]
        public CustomFieldList CustomFields { get; set; }

        [JsonProperty(PropertyName = "pipelines")]
        public object PipeLines { get; set; }

        [JsonProperty(PropertyName = "note_types")]
        public ReadOnlyCollection<NoteType> NoteTypes { get; set; }
    }
}
