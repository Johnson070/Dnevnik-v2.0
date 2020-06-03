using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnevnik.DnevnikClasses
{
    /// <summary>
    /// Класс с конечными сгенерированными оценками для среднего балла
    /// </summary>
    public class MarksDataAverage
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
        public int countBalls;

        /// <summary>
        /// Предыдущий средний балл
        /// </summary>
        public float oldBall;

        /// <summary>
        /// Тип таблицы
        /// </summary>
        public bool type;
    }
}
