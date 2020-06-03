using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnevnik.DnevnikClasses
{
    /// <summary>
    /// Класс группы
    /// </summary>
    public class Groups
    {
        /// <summary>
        /// id группы
        /// </summary>
        public long id;

        /// <summary>
        /// Имя группы
        /// </summary>
        public string name;

        /// <summary>
        /// Год обучения
        /// </summary>
        public int year;

        /// <summary>
        /// Список подгрупп
        /// </summary>
        public List<SubGroups> subGroups;
    }

    /// <summary>
    /// Класс подгруппы
    /// </summary>
    public class SubGroups
    {
        /// <summary>
        /// Начало периода
        /// </summary>
        public DateTime startDate;

        /// <summary>
        /// Конец периода
        /// </summary>
        public DateTime endTime;

        /// <summary>
        /// Тип подгруппы
        /// </summary>
        public string type;

        /// <summary>
        /// Имя подгруппы
        /// </summary>
        public string name;
    }
}
