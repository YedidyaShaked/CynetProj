using CovidTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracker
{
    public class Utils
    {
        public static HashSet<string> GetEMailListForQuarantine(IEnumerable<Log> pastWeekLogs, int id)
        {

            HashSet<string> tempEmailList = new HashSet<string>();
            HashSet<string> emailList = new HashSet<string>();
            bool isSickEmployeeLogedIn = false;

            foreach (Log log in pastWeekLogs)
            {
                if (log.EmployeeId == id)
                {
                    if (!isSickEmployeeLogedIn)
                    {
                        emailList.UnionWith(tempEmailList);
                    }

                    isSickEmployeeLogedIn = !isSickEmployeeLogedIn;
                    continue;
                }

                if (isSickEmployeeLogedIn)
                {
                    emailList.Add(log.Employee.Email);
                }

                if (!tempEmailList.Add(log.Employee.Email))
                {
                    tempEmailList.Remove(log.Employee.Email);
                }
            }

            return emailList;
        }
    }
}
