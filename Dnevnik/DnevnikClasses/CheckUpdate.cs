using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dnevnik.DnevnikClasses
{
    class CheckUpdate
    {
        public void CheckProgramUpdate()
        {

        }

        public string GetChangeLog()
        {
            string change_log = "";

            using (WebClient Client = new WebClient())
            {
                Client.Encoding = Encoding.UTF8;
                change_log = Client.DownloadString("https://raw.githubusercontent.com/Johnson070/Dnevnik-v2.0/master/change_log.txt");
            }

            return change_log;
        }
    }
}
