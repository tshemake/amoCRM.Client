using System;
using System.Collections.Generic;
using System.Text;

namespace amoCRM.Library.Core.Types
{
    public enum ModelType : byte
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
    }
}
