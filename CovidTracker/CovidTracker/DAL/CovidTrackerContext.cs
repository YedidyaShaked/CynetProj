using CovidTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracker.DAL
{
    public class CovidTrackerContext : DbContext
    {
        public CovidTrackerContext(DbContextOptions<CovidTrackerContext> opt) : base(opt)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
