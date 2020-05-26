using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dnevnik
{
    public class MarksTable
    {
        public DataGridView marks { get; set; }
        public List<string> nameLess { get; set; } = new List<string> { "Английский язык", "Астрономия", "Естествознание", "Информатика", "История", "Литература", "Математика", "ОБЖ", "Обществознание", "Программирование", "Русский язык", "Физика", "Физ-ра" };
        //public virtual object mark { get; set; }

        public virtual void drawGrid(int columns, List<string> _name) { }

        public virtual void columnGenBallWeight(int col = 1) { }

        internal virtual DataGridViewRow CloneWithValues(DataGridViewRow row) => null;

        public virtual void upDownRow(bool direct) { }

        public virtual void resultBall(List<List<int>> _mark) { }

        public virtual void resultBall(List<List<int[]>> _mark) { }

        public virtual void inputMark() { }

        public virtual void checkCell() { }

        internal virtual int[] str2intArr(string marksStr = "") => null;

        internal virtual void listMarksRecurse(List<List<int[]>> _marks, List<int[]> itogMarks, int len, int[] _mark = null, int listNum = 0) { }

        internal virtual void listMarksRecurse(List<List<int[]>> _marks, List<int[]> itogMarks, int[] len, int[] _mark = null, int listNum = 0) { }

        internal virtual void genMarksRecurse(int lenght, List<int[]> _test, int start = 2, string marks = "") { }

        internal virtual int getPosState(int[] _numBalls, int startPos = 0) => 0;

        internal virtual void sortCriteriaRecurse(sortMarkStructSr sort, List<float> _averBall) { }

        internal virtual void sortCriteriaRecurse(int[] _numBalls, sortMarkStruct sort, List<float> _averBall) { }

        //private type getPerem<type>(type _input)
        //{
        //    return _input;
        //}

        public virtual int getCountBalls(int _numBalls, bool mode = true) => 0;

        public virtual int getCountBalls(int[] _numBalls, bool mode = true) => 0;

        internal virtual long factFunc(long inFact) => 0;

        public virtual long countMarksRow(int k) => 0;

        public virtual long countMarksRow(int k, int[] numBalls) => 0;

        internal virtual List<float> sortMarks(sortMarkStructSr sort, int _numBalls, List<int> _marksWeights) => null;

        internal virtual List<float> sortMarks(sortMarkStruct sort, int[] _numBalls, List<int[]> _marksWeights) => null;

        public virtual marksDataClassSr genMarks(int numBalls, int[] _criteria, float[] _averBall, List<int> _marksWeights) => null;

        public virtual marksDataClass genMarks(int[] numBalls, List<int[]> _criteria, float[] _averBall, List<int[]> _marksWeights) => null;

        public virtual void editTable(int type) { }//1-addRow 2-deleteRow 3-addColumn 4-deleteColumn

        public virtual void colorTableMarks() { }

        public virtual void genMarksForm() { }

        public virtual void cellFormating() { }

        public virtual void cellClearNotValid() { }
    }
}
