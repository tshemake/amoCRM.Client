﻿using System;
using System.Collections.Generic;
using System.Text;

namespace amoCRM.Library.Requests
{
    public enum RequestType : byte
    {
        Unknown = 0,

        /// <summary>
        /// Контакт.
        /// </summary>
        Contact = 1,

        /// <summary>
        /// Сделка.
        /// </summary>
        Lead = 2,

        /// <summary>
        /// Компания.
        /// </summary>
        Company = 3,

        /// <summary>
        /// Покупатель.
        /// </summary>
        Customer = 12,
        CustomField,
        Authorization,
        Account,
        CurrentAccount,
        Note,
        Task,
        Catalog,
        ElementOfCatalog,
        IncomingLead,
        Other
    }
}
