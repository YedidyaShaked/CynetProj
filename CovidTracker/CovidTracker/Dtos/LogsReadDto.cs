using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracker.Dtos
{
    public class LogsReadDto
    {
        public DateTime LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
    }
}
