using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnevnik.DnevnikClasses
{
    /// <summary>
    /// Класс с конечными сгенерированными оценками для среднего взвешенного балла
    /// </summary>
    public class MarksDataAverageMass
    {
        /// <summary>
        /// Список оценок
        /// </summary>
        public List<int[]> marks;

        /// <summary>
        /// Список средних баллов
        /// </summary>
        public List<float> averBall;

        /// <summary>
        /// Кол-во оценок в одной последовательности
        /// </summary>
        public int[] countBalls;

        /// <summary>
        /// Предыдущий средний балл
        /// </summary>
        public float oldBall;
    }
}
