using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnevnik.DnevnikClasses
{
    /// <summary>
    /// Структура с данными для сортировки генерируемых оценок среднего взвешенного
    /// </summary>
    struct SortMarkStructAverageMass
    {
        /// <summary>
        /// Оценки для сортирвки
        /// </summary>
        public List<int[]> marks { get; set; }

        /// <summary>
        /// Критерии сортировки
        /// </summary>
        public List<int[]> criteria { get; set; }

        /// <summary>
        /// Средний балл сортировки
        /// </summary>
        public float[] averBall { get; set; }
    }
}
