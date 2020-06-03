using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dnevnik.DnevnikClasses
{
    /// <summary>
    /// Класс для работы с таблицей
    /// </summary>
    public class MarksTable
    {
        /// <summary>
        /// Тип таблицы
        /// <list type="bullet">
        /// <item>true - средний балл</item>
        /// <item>false - средний взвешенный балл</item>
        /// </list>
        /// </summary>
        public bool type;

        /// <summary>
        /// Было начато редактирование таблицы
        /// </summary>
        public bool startEdit = false;

        /// <summary>
        /// Открыт ли файл
        /// </summary>
        public bool fileOpen = false;

        /// <summary>
        /// Таблица
        /// </summary>
        public DataGridView marks { get; set; }

        /// <summary>
        /// Последовательность с названиями предметов
        /// </summary>
        public List<string> nameLess { get; set; } = new List<string> { "Английский язык", "Астрономия", "Естествознание", "Информатика", "История", "Литература", "Математика", "ОБЖ", "Обществознание", "Программирование", "Русский язык", "Физика", "Физ-ра" };
        //public virtual object mark { get; set; }

        /// <summary>
        /// Создать в таблице начальные столбцы и строки
        /// </summary>
        /// <param name="columns">Кол-во столбцов</param>
        /// <param name="name">Список названий предметов</param>
        public virtual void DrawGrid(int columns, List<string> name) { }

        /// <summary>
        /// Создать в таблице определённое кол-во столбцов
        /// </summary>
        /// <param name="col">Кол-во столбцов</param>
        public virtual void ColumnGenBallWeight(int col = 1) { }

        /// <summary>
        /// Копировать строку из таблицы
        /// </summary>
        /// <param name="row">строка</param>
        /// <returns></returns>
        internal virtual DataGridViewRow CloneWithValues(DataGridViewRow row) => null;

        /// <summary>
        /// Опускает или поднимает строку
        /// </summary>
        /// <param name="direct">
        /// <list type="bullet">
        /// <listheader>Направление строки:</listheader>
        /// <item>false - вниз</item>
        /// <item>true - вверх</item>
        /// </list>
        /// </param>
        public virtual void UpDownRow(bool direct) { }

        /// <summary>
        /// Посчитать итоговый балл
        /// </summary>
        /// <param name="mark">Список оценок</param>
        public virtual void ResultBall(List<List<int>> mark) { }

        /// <summary>
        /// Посчитать итоговый балл
        /// </summary>
        /// <param name="mark">Список оценок</param>
        public virtual void ResultBall(List<List<int[]>> mark) { }

        /// <summary>
        /// Внести оценки из таблицы в список
        /// </summary>
        public virtual void InputMark() { }

        /// <summary>
        /// Проверка таблицы на ошибки
        /// </summary>
        public virtual void CheckCell() { }

        /// <summary>
        /// Перевод набора чисел в одномерный числовой массив
        /// </summary>
        /// <param name="marksStr"></param>
        /// <returns></returns>
        internal virtual int[] Str2intArr(string marksStr = "") => null;

        /// <summary>
        /// Собирает все возможные варианты перестановок оценок
        /// </summary>
        /// <param name="marks">Список оценок</param>
        /// <param name="itogMarks">Готовый список оценок</param>
        /// <param name="len">Длина последовательности</param>
        /// <param name="mark">Генерируемая последовательность</param>
        /// <param name="listNum">Длинна массива</param>
        internal virtual void ListMarksRecurse(
            List<List<int[]>> marks,
            List<int[]> itogMarks,
            int len,
            int[] mark = null,
            int listNum = 0) { }

        /// <summary>
        /// Собирает все возможные варианты перестановок оценок
        /// </summary>
        /// <param name="marks">Список оценок</param>
        /// <param name="itogMarks">Готовый список оценок</param>
        /// <param name="len">Длина последовательности</param>
        /// <param name="mark">Генерируемая последовательность</param>
        /// <param name="listNum">Длинна массива</param>
        internal virtual void ListMarksRecurse(
            List<List<int[]>> marks,
            List<int[]> itogMarks,
            int[] len,
            int[] mark = null,
            int listNum = 0) { }

        /// <summary>
        /// Генерация последовательности оценок без повторений
        /// </summary>
        /// <param name="lenght">Кол-во оценок</param>
        /// <param name="marksList">Список оценок</param>
        /// <param name="start">Стартовый индекс</param>
        /// <param name="marks">Генерируемая последовательность оценок</param>
        internal virtual void GenMarksRecurse(
            int lenght,
            List<int[]> marksList,
            int start = 2,
            string marks = "") { }

        /// <summary>
        /// Получает индекс в массиве, который не равен 0
        /// </summary>
        /// <param name="numBalls">Последовательность из кол-ва генерируемых оценок каждого типа</param>
        /// <param name="startPos">Начальная позиция поиска в массиве</param>
        /// <returns></returns>
        internal virtual int GetPosState(int[] numBalls, int startPos = 0) => 0;

        /// <summary>
        /// Сортировка списка сгенерированных оценок
        /// </summary>
        /// <param name="sort">Структура в который находятся критерии для сортировки</param>
        /// <param name="averBall">Список со средними баллами</param>
        internal virtual void SortCriteriaRecurse(
            SortMarkStructAverage sort,
            List<float> averBall) { }

        /// <summary>
        /// Сортировка списка сгенерированных оценок
        /// </summary>
        /// <param name="numBalls">Последовательность из кол-ва генерируемых оценок каждого типа</param>
        /// <param name="sort">Структура в который находятся критерии для сортировки</param>
        /// <param name="averBall">Список со средними баллами</param>
        internal virtual void SortCriteriaRecurse(
            int[] numBalls,
            SortMarkStructAverageMass sort,
            List<float> averBall) { }

        //private type getPerem<type>(type _input)
        //{
        //    return _input;
        //}

        /// <summary>
        /// Считает сколько нужно сгенерировать оценок
        /// </summary>
        /// <param name="numBalls">Последовательность из кол-ва генерируемых оценок каждого типа</param>
        /// <param name="mode">
        /// <list type="bullet">
        /// <listheader>Тип работы:</listheader>
        /// <item>true - считает сколько типов работ</item>
        /// <item>false - выдает кол-во оценок</item>
        /// </list>
        /// </param>
        /// <returns></returns>
        public virtual int GetCountBalls(
            int[] numBalls,
            bool mode = true) => 0;

        /// <summary>
        /// Возведение в факториал
        /// </summary>
        /// <param name="inFact">Рекурсия</param>
        /// <returns></returns>
        internal virtual decimal FactFunc(decimal inFact) => 0;

        /// <summary>
        /// Считает кол-во генерируемых вариантов оценок
        /// </summary>
        /// <param name="countMarks">Кол-во оценок</param>
        /// <returns></returns>
        public virtual decimal CountMarksRow(int countMarks) => 0;

        /// <summary>
        /// Считает кол-во генерируемых вариантов оценок
        /// </summary>
        /// <param name="countMarks">Кол-во оценок</param>
        /// <param name="numBalls">Последовательность из кол-ва генерируемых оценок каждого типа</param>
        /// <returns></returns>
        public virtual decimal CountMarksRow(
            int countMarks,
            int[] numBalls) => 0;

        /// <summary>
        /// Расчет среднего балла и сортировка по критериям
        /// </summary>
        /// <param name="sort">Критерии сортировки</param>
        /// <param name="numBalls">Последовательность из кол-ва генерируемых оценок каждого типа</param>
        /// <param name="marksWeights">Последовательность оценок, которая была внесена в таблицу</param>
        /// <returns></returns>
        internal virtual List<float> SortMarks(
            SortMarkStructAverage sort,
            int numBalls,
            List<int> marksWeights) => null;

        /// <summary>
        /// Расчет среднего взвешенного балла и сортировка по критериям
        /// </summary>
        /// <param name="sort">Критерии сортировки</param>
        /// <param name="numBalls">Последовательность из кол-ва генерируемых оценок каждого типа</param>
        /// <param name="marksWeights">Последовательность оценок, которая была внесена в таблицу</param>
        /// <returns></returns>
        internal virtual List<float> SortMarks(
            SortMarkStructAverageMass sort,
            int[] numBalls,
            List<int[]> marksWeights) => null;

        /// <summary>
        /// Генерирует последовательность оценок для среднего балла
        /// </summary>
        /// <param name="numBalls">Последовательность из кол-ва генерируемых оценок каждого типа</param>
        /// <param name="criteria">Последовательность с параметрами индивидуальной сложности оценок</param>
        /// <param name="_averBall">Последовательность с параметрами сортировки по среднему баллу</param>
        /// <param name="marksWeights">Последовательность оценок, которая была внесена в таблицу</param>
        /// <returns></returns>
        public virtual MarksDataAverage GenMarks(
            int numBalls,
            int[] criteria,
            float[] _averBall,
            List<int> marksWeights) => null;

        /// <summary>
        /// Генерирует последовательность оценок для среднего взвешенного балла
        /// </summary>
        /// <param name="numBalls">Последовательность из кол-ва генерируемых оценок каждого типа</param>
        /// <param name="criteria">Последовательность с параметрами индивидуальной сложности оценок</param>
        /// <param name="_averBall">Последовательность с параметрами сортировки по среднему баллу</param>
        /// <param name="marksWeights">Последовательность оценок, которая была внесена в таблицу</param>
        /// <returns></returns>
        public virtual MarksDataAverageMass GenMarks(
            int[] numBalls,
            List<int[]> criteria,
            float[] _averBall,
            List<int[]> marksWeights) => null;

        /// <summary>
        /// Разные действия с таблицей
        /// </summary>
        /// <param name="type">
        /// <list type="bullet">
        /// <listheader>Действие</listheader>
        /// <item>1-добавить строку</item>
        /// <item>2-удалить строку</item>
        /// <item>3-добавить столбец</item>
        /// <item>4-удалить столбец</item>
        /// </list>
        /// </param>
        public virtual void EditTable(int type) { }//1-addRow 2-deleteRow 3-addColumn 4-deleteColumn

        /// <summary>
        /// Цветное выделение оценок
        /// </summary>
        public virtual void ColorTableMarks() { }

        /// <summary>
        /// Вызов окна для выбора критериев с последующей генерацией оценок, выбора, и вставки в таблицу
        /// </summary>
        public virtual void GenMarksForm() { }

        /// <summary>
        /// Форматирование таблицы
        /// </summary>
        public virtual void TableFormating() { }

        /// <summary>
        /// Удалить неправильно заполненные ячейки
        /// </summary>
        public virtual void CellClearNotValid() { }
    }
}
