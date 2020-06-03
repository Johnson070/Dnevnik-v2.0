using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiDiaryLibrary;

namespace Dnevnik.DnevnikClasses
{
    class Analytics
    {
        readonly ApiDiary api;

        public Analytics(ApiDiary api) => this.api = api;

        //public void test(long groupId)
        //{
        //    var context = api.GetSchoolHomework(1);

        //    var testAnalytics = api.GetGroupMarks(groupId);

        //    var testAverage = api.GetGroupAverageMarksByTime(groupId, new DateTime(2020, 01, 01), new DateTime(2020, 05, 30));

        //    var testAverageAll = api.GetGroupAverageMarksByTime(groupId, new DateTime(2020, 01, 01), new DateTime(2020, 05, 30));
        //}
    }
}
