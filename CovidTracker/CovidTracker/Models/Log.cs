using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracker.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required]
        public DateTime LogTime { get; set; }

        [Required]
        public bool IsLogin { get; set; }
    }
}
