using System;
using System.Collections.Generic;
using System.Text;

namespace amoCRM.Library.Requests
{
    public enum RequestType : byte
    {
        Unknown = 0,
        Authorization,
        Account,
        Contact,
        Company,
        Lead,
        Note,
        Task,
        Catalog,
        ElementOfCatalog,
        Customer,
        Other
    }
}
