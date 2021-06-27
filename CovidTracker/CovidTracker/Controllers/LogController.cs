using AutoMapper;
using CovidTracker.DAL;
using CovidTracker.Dtos;
using CovidTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracker.Controllers
{
    [Route("api/log")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ICovidTrackerRepo _repo;

        public IMapper _mapper { get; }

        public LogController(ICovidTrackerRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET api/log/{id}
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<LogsReadDto>> GetAllEmployeeLogs(int id)
        {
            try
            {
                var employeeLogs = _repo.GetAllEmployeeLogs(id);

                return Ok(Utils.CoupleLogs(employeeLogs));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return NotFound();
            }
        }

        // POST api/log/{id}
        [HttpPost("{id}")]
        public ActionResult<LogReadDto> CreateLog(int id)
        {
            try
            {
                var employee = _repo.GetEmployeeById(id);

                if (employee == null)
                {
                    return NotFound();
                }

                employee.IsLogedIn = !employee.IsLogedIn;
                var log = new Log() { EmployeeId = id, LogTime = DateTime.Now, IsLogin = employee.IsLogedIn};

                _repo.CreateLog(log);

                if (!_repo.SaveChanges())
                {
                    return NotFound();
                }

                return CreatedAtRoute(nameof(EmployeeController.GetEmployeeById), new { Id = log.Id }, log);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return NotFound();
            }
        }

        // GET api/log/sick/{id}
        [HttpGet("reportSick/{id}")]
        public ActionResult<HashSet<string>> ReportSick(int id)
        {
            try
            {
                if (_repo.GetEmployeeById(id) == null)
                {
                    return NotFound();
                }

                var pastWeekLogs = _repo.GetLogsOfPastWeek(id);

                var emailList = Utils.GetEMailListForQuarantine(pastWeekLogs, id);

                Console.WriteLine(emailList);

                return Ok(emailList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return NotFound();
            }
        }
    }
}
