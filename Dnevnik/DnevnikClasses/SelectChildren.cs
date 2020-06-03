using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnevnik.DnevnikClasses
{
    /// <summary>
    /// Выбранный пользователя
    /// </summary>
    internal class SelectChildren
    {
        /// <summary>
        /// Класс для сброса таблицы
        /// </summary>
        public ResetClass Reset;

        /// <summary>
        /// Конец периода
        /// </summary>
        public DateTime EndDate;

        /// <summary>
        /// Начало периода
        /// </summary>
        public DateTime StartDate;

        /// <summary>
        /// Персона
        /// </summary>
        public Persons Member;

        /// <summary>
        /// Группа персоны
        /// </summary>
        public Groups group;

        /// <summary>
        /// Класс с таблицей
        /// </summary>
        public MarksTable table;
    }
}
