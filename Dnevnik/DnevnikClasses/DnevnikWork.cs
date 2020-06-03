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
        /// <summary>
        /// Инициализация класса
        /// </summary>
        /// <param name="keyAccess">Токен</param>
        public DnevnikWork(string keyAccess) => api = new ApiDiary(keyAccess);

        /// <summary>
        /// Класс для работы с api
        /// </summary>
        readonly ApiDiary api;

        /// <summary>
        /// Для для работы в отдельном потоке
        /// </summary>
        ResultWorker work;

        /// <summary>
        /// Найти самое большое кол-во оценок в списке
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private int MaxCountBalls(List<List<InputMark>> count)
        {
            int max = 2;

            for (int i = 0; i < count.Count; i++)
            {
                if (count[i].Count > max) max = count[i].Count;
            }

            return max;
        }

        /// <summary>
        /// Класс для хранения оценки
        /// </summary>
        class InputMark
        {
            /// <summary>
            /// Оценка
            /// </summary>
            public int mark;

            /// <summary>
            /// Тип работы
            /// </summary>
            public long typeWork;

            /// <summary>
            /// Название работы
            /// </summary>
            public string nameWork;
        }


        /// <summary>
        /// Получить список детей у пользователя или самого пользователя
        /// </summary>
        /// <returns></returns>
        public List<List<Persons>> GetMembers()
        {
            List<List<Persons>> ids = new List<List<Persons>>() { new List<Persons>() };
            List<string> roles = new List<string>();

            var info = ((JObject)JsonConvert.DeserializeObject(api.GetContext()))["roles"].ToObject<JArray>();

            //var classmates = ((JArray)JsonConvert.DeserializeObject(api.GetGroupPersons(group.id, (groups[i].year >= DateTime.UtcNow.Year - 1 && groups[i].year <= DateTime.UtcNow.Year) ? false : true)));

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

                ids[0].Add(new Persons() { userId = ((JObject)JsonConvert.DeserializeObject(context))["userId"].Value<long>(), personId = ((JObject)JsonConvert.DeserializeObject(api.GetContext()))["personId"].Value<long>(), userName = ((JObject)JsonConvert.DeserializeObject(api.GetContext()))["shortName"].Value<string>() });
            }
            else
            {
                var childrens = ((JArray)JsonConvert.DeserializeObject(api.GetChildren())).ToObject<JArray>();
                var context = ((JObject)JsonConvert.DeserializeObject(api.GetContext()))["children"].ToObject<JArray>();

                int j = 0;

                foreach (JObject children in context)
                {
                    ids[0].Add(new Persons() { personId = children["personId"].Value<long>(), userName = children["shortName"].Value<string>(), userId = childrens[j].Value<long>() });
                    j++;
                }
            }

            return ids;
        }

        /// <summary>
        /// Получить список детей у пользователя или самого пользователя + можно получить еще список одноклассников
        /// </summary>
        /// <param name="groups">Список групп в которых находится пользователь</param>
        /// <param name="getClassmates">Добавлять в список одноклассников</param>
        /// <returns></returns>
        public List<List<Persons>> GetMembers(List<List<Groups>> groups, bool getClassmates = true)
        {
            List<List<Persons>> ids = new List<List<Persons>>();


            for (int i = 0; i < groups.Count; i++)
            {
                for (int j = 0; j < groups[i].Count; j++)
                {
                    ids.Add(new List<Persons>());

                    List<string> roles = new List<string>();

                    var group = groups[i][j];
                    var info = ((JObject)JsonConvert.DeserializeObject(api.GetContext()))["roles"].ToObject<JArray>();

                    var classmates = ((JArray)JsonConvert.DeserializeObject(api.GetGroupPersons(group.id, (group.year >= DateTime.UtcNow.Year - 1 && group.year <= DateTime.UtcNow.Year) ? false : true)));

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

                    if (isStudent && !getClassmates)
                    {
                        var context = api.GetContext();

                        ids[j].Add(new Persons() { userId = ((JObject)JsonConvert.DeserializeObject(context))["userId"].Value<long>(), personId = ((JObject)JsonConvert.DeserializeObject(api.GetContext()))["personId"].Value<long>(), userName = ((JObject)JsonConvert.DeserializeObject(api.GetContext()))["shortName"].Value<string>() });
                    }
                    else if (!getClassmates)
                    {
                        var childrens = ((JArray)JsonConvert.DeserializeObject(api.GetChildren())).ToObject<JArray>();
                        var context = ((JObject)JsonConvert.DeserializeObject(api.GetContext()))["children"].ToObject<JArray>();

                        int k = 0;

                        foreach (JObject children in context)
                        {
                            ids[j].Add(new Persons() { personId = children["personId"].Value<long>(), userName = children["shortName"].Value<string>(), userId = childrens[k].Value<long>() });
                            k++;
                        }
                    }

                    if (getClassmates) //  && (groups[i].year == DateTime.UtcNow.Year-1 || groups[i].year == DateTime.UtcNow.Year)
                        foreach (JObject person in classmates)
                        {
                            try
                            {
                                ids[j].Add(new Persons() { personId = person["id"].Value<long>(), userName = person["shortName"].Value<string>(), userId = person["userId"].Value<long>() });
                            }
                            catch { }
                        }
                }
            }

            return ids;
        }

        /// <summary>
        /// Класс для хранения уроков по предмету
        /// </summary>
        class TempWork
        {
            /// <summary>
            /// Работы
            /// </summary>
            public JArray work;

            /// <summary>
            /// id предмета
            /// </summary>
            public long subject;

            /// <summary>
            /// Инициализация класса
            /// </summary>
            /// <param name="work">Работы</param>
            /// <param name="subject">id предмета</param>
            public TempWork(JArray work, long subject)
            {
                this.work = work;
                this.subject = subject;
            }
        }

        /// <summary>
        /// Класс результата работы потока
        /// </summary>
        class ResultWorker
        {
            /// <summary>
            /// Список оценок
            /// </summary>
            public List<List<InputMark>> marks;

            /// <summary>
            /// Список названий предметов
            /// </summary>
            public List<string> nameLesson;

            /// <summary>
            /// Класс с таблицей
            /// </summary>
            public MarksTable table;

            /// <summary>
            /// Класс для сброса markstable и таблицы
            /// </summary>
            public ResetClass rst;

            /// <summary>
            /// Список с типами работ
            /// </summary>
            public JArray typeWork;
        }

        /// <summary>
        /// Получить все группы для списка пользователей
        /// </summary>
        /// <param name="persons">Список пользователей</param>
        /// <returns></returns>
        public List<List<Groups>> GetAllGroups(List<List<Persons>> persons)
        {
            List<List<Groups>> groups = new List<List<Groups>>();

            for (int i = 0; i < persons.Count; i++)
                for (int j = 0; j < persons[i].Count; j++)
                {
                    groups.Add(new List<Groups>());

                    var groupsJ = ((JArray)JsonConvert.DeserializeObject(api.GetPersonGroupsAll(persons[i][j].personId)));

                    foreach (JObject group in groupsJ)
                        if (group["type"].Value<string>() == "Group")
                        {
                            var dataGroups = (JArray)JsonConvert.DeserializeObject(api.GetGroupReports(group["id"].Value<long>()));

                            List<SubGroups> subGroups = new List<SubGroups>();

                            foreach (JObject dataGroup in dataGroups)
                                subGroups.Add(new SubGroups() { type = dataGroup["type"].Value<string>(), name = dataGroup["name"].Value<string>(), startDate = dataGroup["start"].Value<DateTime>(), endTime = dataGroup["finish"].Value<DateTime>() });

                            groups[i].Add(new Groups() { id = group["id"].Value<long>(), name = group["name"].Value<string>(), year = group["studyyear"].Value<int>(), subGroups = subGroups });
                        }
                }

            return groups;
        }

        /// <summary>
        /// Пулучить список id уроков по информации об уроке
        /// </summary>
        /// <param name="lessons">Список уроков</param>
        /// <returns></returns>
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

        /// <summary>
        /// Получить оценки для пользователя
        /// </summary>
        /// <param name="children">Пользователь</param>
        public void GetMarksDiary(SelectChildren children)
        {
            var groupId = children.group.id;

            var schoolId = ((JArray)JsonConvert.DeserializeObject(api.GetSchool()))[0]["id"].Value<long>();

            var lessons = ((JArray)JsonConvert.DeserializeObject(api.GetGroupSubjects(groupId)));

            var typeWork = ((JArray)JsonConvert.DeserializeObject(api.GetWorkTypes(schoolId)));

            List<List<InputMark>> marks = new List<List<InputMark>>();
            List<string> nameLesson = new List<string>();

            foreach (JObject lesson in lessons)
            {
                nameLesson.Add(lesson["name"].Value<string>());
            }

            var marksPerson = (JArray)JsonConvert.DeserializeObject(api.GetPersonGroupMarks(children.Member.personId, groupId, children.StartDate, children.EndDate));

            var lessonsIds = GetLessonId(((JArray)JsonConvert.DeserializeObject(api.GetGroupLessonsInfo(groupId, children.StartDate, children.EndDate))));

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

            work = new ResultWorker() { table = children.table, rst = children.Reset, marks = marks, nameLesson = nameLesson, typeWork = typeWork };
        }

        /// <summary>
        /// Вставка оценок в таблицу
        /// </summary>
        public void InsertMarksInTable() // переписать метод в MarksTableAverage и MarksTableAverageMass
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
