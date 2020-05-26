using ApiDiaryLibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dnevnik.DnevnikClasses
{
    class DnevnikWork
    {
        public DnevnikWork(string keyAccess) => api = new ApiDiary(keyAccess);

        readonly ApiDiary api;
        ResultWorker work;

        private int MaxCountBalls(List<List<InputMark>> count)
        {
            int max = 2;

            for (int i = 0; i < count.Count; i++)
            {
                if (count[i].Count > max) max = count[i].Count;
            }

            return max;
        }

        class InputMark
        {
            public int mark;
            public long typeWork;
            public string nameWork;
        }

        public List<List<Persons>> GetMembers(List<Groups> groups, bool getClassmates = true)
        {
            List<List<Persons>> ids = new List<List<Persons>>();

            for (int i = 0; i < groups.Count; i++)
            {
                List<string> roles = new List<string>();
                ids.Add(new List<Persons>());

                var group = groups[i];
                var info = ((JObject)JsonConvert.DeserializeObject(api.GetContext()))["roles"].ToObject<JArray>();
                var classmates = ((JArray)JsonConvert.DeserializeObject(api.GetGroupPersons(group.id)));

                foreach (string roleArray in info)
                {
                    roles.Add(roleArray);
                }

                bool isStudent = false;

                foreach (string role in roles)
                {
                    if (role == "EduStudent")
                    {
                        isStudent = true;
                    }
                    else
                    {
                        isStudent = false;
                        break;
                    }
                }

                if (isStudent)
                {
                    var context = api.GetContext();

                    ids[i].Add(new Persons() { userId = ((JObject)JsonConvert.DeserializeObject(context))["userId"].Value<long>(), personId = ((JObject)JsonConvert.DeserializeObject(api.GetContext()))["personId"].Value<long>(), userName = ((JObject)JsonConvert.DeserializeObject(api.GetContext()))["shortName"].Value<string>() });
                    //ids.Add(((JObject)JsonConvert.DeserializeObject(api.GetContext()))["userId"].Value<long>());
                    //ids.Add(((JObject)JsonConvert.DeserializeObject(api.GetContext()))["personId"].Value<long>());
                }
                else
                {
                    var childrens = ((JArray)JsonConvert.DeserializeObject(api.GetChildren())).ToObject<JArray>();
                    var context = ((JObject)JsonConvert.DeserializeObject(api.GetContext()))["children"].ToObject<JArray>();

                    int j = 0;

                    foreach (JObject children in context)
                    {
                        ids[i].Add(new Persons() { personId = children["personId"].Value<long>(), userName = children["shortName"].Value<string>(), userId = childrens[j].Value<long>() });
                        j++;
                    }
                }

                if (getClassmates)
                    foreach (JObject person in classmates)
                    {
                        ids[i].Add(new Persons() { personId = person["id"].Value<long>(), userName = person["shortName"].Value<string>(), userId = person["userId"].Value<long>() });
                    }
            }

            return ids;
        }

        class TempWork
        {
            public JArray work;
            public long subject;

            public TempWork(JArray work, long subject)
            {
                this.work = work;
                this.subject = subject;
            }
        }

        class ResultWorker
        {
            public List<List<InputMark>> marks;
            public List<string> nameLesson;
            public MarksTable table;
            public ResetClass rst;
            public JArray typeWork;
        }

        public List<Groups> GetAllGroups(long personId)
        {
            var groupsJ = ((JArray)JsonConvert.DeserializeObject(api.GetPersonGroupsAll(personId)));

            List<Groups> groups = new List<Groups>();

            foreach (JObject group in groupsJ)
                if (group["type"].Value<string>() == "Group")
                {
                    groups.Add(new Groups() { id = group["id"].Value<long>(), name = group["name"].Value<string>(), year = group["studyyear"].Value<int>() });
                }

            return groups;
        }


        private List<long[]> GetLessonId(JArray lessons)
        {
            List<long[]> lessonsIds = new List<long[]>();
            List<TempWork> works = new List<TempWork>();

            foreach (JObject lesson in lessons)
                works.Add(new TempWork((lesson["works"].ToObject<JArray>()), (lesson["subject"].ToObject<JObject>()["id"].Value<long>())));

            foreach (TempWork work in works)
            {
                foreach (JObject lesson in work.work)
                {
                    long lessonIdLong = lesson["lesson"].Value<long>();

                    bool isMatch = true;

                    foreach (long[] id in lessonsIds)
                    {
                        if (lessonIdLong == id[0])
                        {
                            isMatch = false;
                            continue;
                        }
                    }

                    if (isMatch)
                        lessonsIds.Add(new long[] { lessonIdLong, work.subject });
                }
            }

            return lessonsIds;
        }

        public void GetMarksDiary(MarksTable table, ResetClass rst, DateTime startTime, DateTime endTime, Persons person, Groups group)
        {
            //var groupId = ((JArray)JsonConvert.DeserializeObject(api.GetPersonGroups(person.personId)))[0]["id"].Value<long>();
            var groupId = group.id;

            var schoolId = ((JArray)JsonConvert.DeserializeObject(api.GetSchool()))[0]["id"].Value<long>();

            var jsonLessons = api.GetGroupSubjects(groupId);

            var lessons = ((JArray)JsonConvert.DeserializeObject(jsonLessons));

            var typeWork = ((JArray)JsonConvert.DeserializeObject(api.GetWorkTypes(schoolId)));

            List<List<InputMark>> marks = new List<List<InputMark>>();
            List<string> nameLesson = new List<string>();

            foreach (JObject lesson in lessons)
            {
                nameLesson.Add(lesson["name"].Value<string>());
            }

            var marksPerson = (JArray)JsonConvert.DeserializeObject(api.GetPersonMarks(person.personId, schoolId, startTime, endTime));

            var lessonsIds = GetLessonId(((JArray)JsonConvert.DeserializeObject(api.GetGroupLessonsInfo(groupId, startTime, endTime))));

            /*
             * добавить парсинг значений lesson id из works!!!!!!
             */

            for (int i = 0; i < lessons.Count; i++)
            {
                marks.Add(new List<InputMark>());

                var id = ((JObject)lessons[i])["id"].Value<long>();

                foreach (JObject mark in marksPerson)
                {
                    foreach (long[] lesson in lessonsIds)
                    {
                        if (mark["lesson"].Value<long>() == lesson[0] && id == lesson[1])
                        {
                            marks[i].Add(new InputMark { mark = mark["value"].Value<int>(), typeWork = mark["workType"].Value<long>() });
                        }
                    }
                }
            }

            work = new ResultWorker() { table = table, rst = rst, marks = marks, nameLesson = nameLesson, typeWork = typeWork };
        }

        public void InsertMarksInTable()
        {
            if (work.table is MarksTableAverageMass)
            {
                DataGridView grid = work.table.marks;

                work.rst.Reset(work.table.type);

                work.table = new MarksTableAverageMass
                {
                    marks = grid
                };

                work.table.marks.Rows.Clear();
                work.table.marks.Columns.Clear();

                work.table.DrawGrid(MaxCountBalls(work.marks), work.nameLesson);

                foreach (JObject type in work.typeWork)
                    foreach (List<InputMark> markList in work.marks)
                        foreach (InputMark mark in markList)
                            if (type["id"].Value<long>() == mark.typeWork)
                            {
                                mark.nameWork = type["title"].Value<string>();
                                mark.typeWork = type["weight"].Value<long>();
                            }
            }
            else
            {
                DataGridView grid = work.table.marks;

                work.rst.Reset(work.table.type);

                work.table = new MarksTableAverage
                {
                    marks = grid
                };

                work.table.marks.Rows.Clear();
                work.table.marks.Columns.Clear();

                work.table.DrawGrid(MaxCountBalls(work.marks), work.nameLesson);

                foreach (JObject type in work.typeWork)
                    foreach (List<InputMark> markList in work.marks)
                        foreach (InputMark mark in markList)
                            if (type["id"].Value<long>() == mark.typeWork)
                                mark.nameWork = type["title"].Value<string>();
            }

            if (work.table is MarksTableAverageMass)
            {
                for (int i = 0; i < work.marks.Count; i++)
                {
                    int posCol = 0;

                    for (int j = 0; j < work.marks[i].Count; j++)
                    {
                        work.table.marks[posCol + 1, i].Value = work.marks[i][j].mark;
                        work.table.marks[posCol + 2, i].Value = work.marks[i][j].typeWork;
                        work.table.marks[posCol + 2, i].ToolTipText = work.marks[i][j].nameWork;

                        posCol += 2;
                    }
                }
            }
            else
            {
                for (int i = 0; i < work.marks.Count; i++)
                {
                    int posCol = 0;

                    for (int j = 0; j < work.marks[i].Count; j++)
                    {
                        work.table.marks[posCol + 1, i].Value = work.marks[i][j].mark;

                        posCol++;
                    }
                }
            }
        }
    }
}
