using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnevnik.DnevnikClasses
{
    /// <summary>
    /// Класс для возращаемого значения после логина
    /// </summary>
    class LoginReturn
    {
        /// <summary>
        /// Успешна ли авторизация
        /// <list type="table">
        /// <item>true - да</item>
        /// <item>false - нет</item>
        /// </list>
        /// </summary>
        public bool closedSuccess;

        /// <summary>
        /// Токен доступа к api
        /// </summary>
        public string keyAccess;
    }
}
