using CovidTracker.Dtos;
using CovidTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracker.DAL
{
    public interface ICovidTrackerRepo
    {
        public bool SaveChanges();
        public IEnumerable<Employee> GetAllEmployees();
        public Employee GetEmployeeById(int id);
        public IEnumerable<Log> GetAllEmployeeLogs(int id);
        public void CreateLog(Log log);
        public IEnumerable<Log> GetLogsOfPastWeek(int id);  
    }
}
