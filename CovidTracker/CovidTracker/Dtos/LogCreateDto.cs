using CovidTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracker.Dtos
{
    public class LogCreateDto
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public DateTime LogTime { get; set; }

        [Required]
        public bool IsLogin { get; set; }
    }
}
