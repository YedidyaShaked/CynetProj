using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracker.Dtos
{
    public class LogReadDto
    {
        public EmployeeReadDto Employee { get; set; }

        public DateTime LogTime { get; set; }
        public bool IsLogin { get; set; }
    }
}
