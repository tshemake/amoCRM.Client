using System;
using System.Collections.Generic;
using System.Text;

namespace amoCRM.Library.Helpers
{
    public enum ModelType : byte
    {
        Unknown = 0,
        [StringValue("account")]
        Account,
        [StringValue("company")]
        Company,
        [StringValue("contact")]
        Contact,
        [StringValue("field")]
        Field,
        [StringValue("lead")]
        Lead,
        [StringValue("notes")]
        Note,
        [StringValue("tasks")]
        Task
    }
}
