using CovidTracker.Dtos;
using CovidTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracker.DAL
{
    public class SqlCovidTrackerRepo : ICovidTrackerRepo
    {
        private readonly CovidTrackerContext _context;

        public SqlCovidTrackerRepo(CovidTrackerContext context)
        {
            _context = context;
        }
         
        public void CreateLog(Log log)
        {
            if (log == null)
            {
                throw new ArgumentNullException(nameof(log));
            }

            _context.Logs.Add(log);
        }

        public IEnumerable<Log> GetAllEmployeeLogs(int id)
        {
            return _context.Logs.Where(l => l.Employee.Id == id).Include(l => l.Employee).ToList();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == id); ;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Log> GetLogsOfPastWeek(int id)
        {
            return _context.Logs.Where(l => l.LogTime >= DateTime.Now.AddDays(-7)).
                Include(l => l.Employee).
                OrderBy(l => l.LogTime);
        }
    }
}
