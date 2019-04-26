using System;
using System.Collections.Generic;
using System.Text;
using amoCRM.Library.Core.Types;
using Newtonsoft.Json;

namespace amoCRM.Library.Core.Objects
{
    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "language")]
        public Language Language { get; set; }

        [JsonProperty(PropertyName = "mail_admin")]
        public string MailAdmin { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "login")]
        public string Login { get; set; }

        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }

        /// <summary>
        /// Наличие прав администратора.
        /// </summary>
        [JsonProperty(PropertyName = "is_admin")]
        public YesNo IsAdmin { get; set; }

        [JsonProperty(PropertyName = "unsorted_access")]
        public YesNo UnsortedAccess { get; set; }

        [JsonProperty(PropertyName = "catalogs_access")]
        public YesNo CatalogsAccess { get; set; }

        /// <summary>
        /// id группы, в которой состоит пользователь.
        /// </summary>
        [JsonProperty(PropertyName = "group_id")]
        public int GroupId { get; set; }

        [JsonProperty(PropertyName = "rights_lead_add")]
        public string RightsLeadAdd { get; set; }

        [JsonProperty(PropertyName = "rights_lead_view")]
        public string RightsLeadView { get; set; }

        [JsonProperty(PropertyName = "rights_lead_edit")]
        public string RightsLeadEdit { get; set; }

        [JsonProperty(PropertyName = "rights_lead_delete")]
        public string RightsLeadDelete { get; set; }

        [JsonProperty(PropertyName = "rights_lead_export")]
        public string RightsLeadExport { get; set; }

        [JsonProperty(PropertyName = "rights_contact_add")]
        public string RightsContactAdd { get; set; }

        [JsonProperty(PropertyName = "rights_contact_view")]
        public string RightsContactView { get; set; }

        [JsonProperty(PropertyName = "rights_contact_edit")]
        public string RightsContactEdit { get; set; }

        [JsonProperty(PropertyName = "rights_contact_delete")]
        public string RightsContactDelete { get; set; }

        [JsonProperty(PropertyName = "rights_contact_export")]
        public string RightsContactExport { get; set; }

        [JsonProperty(PropertyName = "rights_company_add")]
        public string RightsCompanyAdd { get; set; }

        [JsonProperty(PropertyName = "rights_company_view")]
        public string RightsCompanyView { get; set; }

        [JsonProperty(PropertyName = "rights_company_edit")]
        public string RightsCompanyEdit { get; set; }

        [JsonProperty(PropertyName = "rights_company_delete")]
        public string RightsCompanyDelete { get; set; }

        [JsonProperty(PropertyName = "rights_company_export")]
        public string RightsCompanyExport { get; set; }

        [JsonProperty(PropertyName = "rights_task_edit")]
        public string RightsTaskEdit { get; set; }

        [JsonProperty(PropertyName = "rights_task_delete")]
        public string RightsTaskDelete { get; set; }

        [JsonProperty(PropertyName = "free_user")]
        public bool FreeUser { get; set; }

        [JsonProperty(PropertyName = "rights_by_status")]
        public RightsByStatus RightsByStatus { get; set; }
    }
}
