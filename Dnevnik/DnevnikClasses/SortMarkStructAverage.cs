using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnevnik.DnevnikClasses
{
    /// <summary>
    /// Структура с данными для сортировки генерируемых оценок
    /// </summary>
    struct SortMarkStructAverage
    {
        /// <summary>
        /// Оценки для сортировки
        /// </summary>
        public List<int[]> marks { get; set; }

        /// <summary>
        /// Критерии сортировки
        /// </summary>
        public int[] criteria { get; set; }

        /// <summary>
        /// Средний балл сортировки
        /// </summary>
        public float[] averBall { get; set; }
    }
}
