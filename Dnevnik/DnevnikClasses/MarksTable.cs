using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dnevnik.DnevnikClasses
{
    public class MarksTable
    {
        public bool type;
        public bool startEdit = false;
        public bool fileOpen = false;
        public DataGridView marks { get; set; }
        public List<string> nameLess { get; set; } = new List<string> { "Английский язык", "Астрономия", "Естествознание", "Информатика", "История", "Литература", "Математика", "ОБЖ", "Обществознание", "Программирование", "Русский язык", "Физика", "Физ-ра" };
        //public virtual object mark { get; set; }

        public virtual void DrawGrid(int columns, List<string> _name) { }

        public virtual void ColumnGenBallWeight(int col = 1) { }

        internal virtual DataGridViewRow CloneWithValues(DataGridViewRow row) => null;

        public virtual void UpDownRow(bool direct) { }

        public virtual void ResultBall(List<List<int>> _mark) { }

        public virtual void ResultBall(List<List<int[]>> _mark) { }

        public virtual void InputMark() { }

        public virtual void CheckCell() { }

        internal virtual int[] Str2intArr(string marksStr = "") => null;

        internal virtual void ListMarksRecurse(
            List<List<int[]>> _marks,
            List<int[]> itogMarks,
            int len,
            int[] _mark = null,
            int listNum = 0) { }

        internal virtual void ListMarksRecurse(
            List<List<int[]>> _marks,
            List<int[]> itogMarks,
            int[] len,
            int[] _mark = null,
            int listNum = 0) { }

        internal virtual void GenMarksRecurse(
            int lenght,
            List<int[]> _test,
            int start = 2,
            string marks = "") { }

        internal virtual int GetPosState(int[] _numBalls, int startPos = 0) => 0;

        internal virtual void SortCriteriaRecurse(
            SortMarkStructAverage sort,
            List<float> _averBall) { }

        internal virtual void SortCriteriaRecurse(
            int[] _numBalls,
            SortMarkStructAverageMass sort,
            List<float> _averBall) { }

        //private type getPerem<type>(type _input)
        //{
        //    return _input;
        //}

        public virtual int GetCountBalls(
            int _numBalls,
            bool mode = true) => 0;

        public virtual int GetCountBalls(
            int[] _numBalls,
            bool mode = true) => 0;

        internal virtual decimal FactFunc(decimal inFact) => 0;

        public virtual decimal CountMarksRow(int k) => 0;

        public virtual decimal CountMarksRow(
            int k,
            int[] numBalls) => 0;

        internal virtual List<float> SortMarks(
            SortMarkStructAverage sort,
            int _numBalls,
            List<int> _marksWeights) => null;

        internal virtual List<float> SortMarks(
            SortMarkStructAverageMass sort,
            int[] _numBalls,
            List<int[]> _marksWeights) => null;

        public virtual MarksDataAverage GenMarks(
            int numBalls,
            int[] _criteria,
            float[] _averBall,
            List<int> _marksWeights) => null;

        public virtual MarksDataAverageMass GenMarks(
            int[] numBalls,
            List<int[]> _criteria,
            float[] _averBall,
            List<int[]> _marksWeights) => null;

        public virtual void EditTable(int type) { }//1-addRow 2-deleteRow 3-addColumn 4-deleteColumn

        public virtual void ColorTableMarks() { }

        public virtual void GenMarksForm() { }

        public virtual void CellFormating() { }

        public virtual void CellClearNotValid() { }
    }
}
