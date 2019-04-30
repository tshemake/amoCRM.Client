using System;
using System.Collections.Generic;
using System.Text;

namespace amoCRM.Library.Core.Types
{
    public enum TaskType : byte
    {
        Unknown = 0,

        /// <summary>
        /// Звонок
        /// </summary>
        Call = 1,

        /// <summary>
        /// Встреча
        /// </summary>
        Meeting = 2,

        /// <summary>
        /// Письмо
        /// </summary>
        Mail = 3,
    }
}
