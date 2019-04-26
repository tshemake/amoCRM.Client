using System;
using System.Collections.Generic;
using System.Text;

namespace amoCRM.Library
{
    public class Account
    {
        /// <summary>
        /// Поддомен.
        /// </summary>
        public string SubDomain { get; set; }

        /// <summary>
        /// Логин пользователя. В качестве логина в системе используется e-mail.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Ключ пользователя, который можно получить на странице редактирования профиля пользователя.
        /// </summary>
        public string Hash { get; set; }
    }
}
