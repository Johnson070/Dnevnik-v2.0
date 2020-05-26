using ApiDiaryLibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dnevnik
{
    class DnevnikWork
    {
        public DnevnikWork(string keyAccess) => api = new ApiDiary(keyAccess);

        ApiDiary api;

        private int maxCountBalls(List<List<inputMark>> count)
        {
            int max = 2;

            for (int i = 0; i < count.Count; i++)
            {
                if (count[i].Count > max) max = count[i].Count;
            }

            return max;
        }

        class inputMark
        {
            public int mark;
            public long typeWork;
            public string nameWork;
        }

        public void InputMarks(MarksTable table, resetClass rst)
        {
            api = new ApiDiary(Properties.Settings.Default.keyAccess);

            var jsonLessons = api.GetGroupSubjects(1556261691152418797);

            var lessons = ((JArray)JsonConvert.DeserializeObject(jsonLessons));

            var typeWork = ((JArray)JsonConvert.DeserializeObject(api.GetWorkTypes(48815)));

            //var homework = dnv.GetSchoolHomework(48815, new DateTime(2020, 05, 18), new DateTime(2020, 05, 24));

            List<List<inputMark>> marks = new List<List<inputMark>>();
            List<string> nameLesson = new List<string>();

            foreach (JObject lesson in lessons)
            {
                nameLesson.Add(lesson["name"].Value<string>());
            }

            for (int i = 0; i < lessons.Count; i++)
            {
                marks.Add(new List<inputMark>());

                var test = ((JObject)lessons[i])["id"].Value<long>();

                var responge = ((JArray)JsonConvert.DeserializeObject(api.GetPersonSubjectMarks(1000009104797, test, new DateTime(2020, 01, 01), new DateTime(2020, 05, 18))));

                foreach (JObject mark in responge)
                {
                    marks[i].Add(new inputMark { mark = mark["value"].Value<int>(), typeWork = mark["workType"].Value<long>() });
                }
            }

            if (table is marksTableClass)
            {
                DataGridView grid = table.marks;

                rst.Reset();

                table = new marksTableClass();

                table.marks = grid;

                table.marks.Rows.Clear();
                table.marks.Columns.Clear();

                table.drawGrid(maxCountBalls(marks), nameLesson);

                foreach (JObject type in typeWork)
                    foreach (List<inputMark> markList in marks)
                        foreach (inputMark mark in markList)
                            if (type["id"].Value<long>() == mark.typeWork) 
                            {
                                mark.nameWork = type["title"].Value<string>();
                                mark.typeWork = type["weight"].Value<long>();
                            }
            }
            else
            {
                DataGridView grid = table.marks;

                rst.Reset();

                table = new marksTableClassSr();

                table.marks = grid;

                table.marks.Rows.Clear();
                table.marks.Columns.Clear();

                table.drawGrid(maxCountBalls(marks), nameLesson);

                foreach (JObject type in typeWork)
                    foreach (List<inputMark> markList in marks)
                        foreach (inputMark mark in markList)
                            if (type["id"].Value<long>() == mark.typeWork)
                                mark.nameWork = type["title"].Value<string>();
            }

            if (table is marksTableClass)
            {
                for (int i = 0; i < marks.Count; i++)
                {
                    int posCol = 0;

                    for (int j = 0; j < marks[i].Count; j++)
                    {
                        table.marks[posCol+1, i].Value = marks[i][j].mark;
                        table.marks[posCol+2, i].Value = marks[i][j].typeWork;
                        table.marks[posCol + 2, i].ToolTipText = marks[i][j].nameWork;

                        posCol+=2;
                    }
                }
            }
            else
            {
                for (int i = 0; i < marks.Count; i++)
                {
                    int posCol = 0;

                    for (int j = 0; j < marks[i].Count; j++)
                    {
                        table.marks[posCol + 1, i].Value = marks[i][j].mark;

                        posCol++;
                    }
                }
            }
        }
    }
}
