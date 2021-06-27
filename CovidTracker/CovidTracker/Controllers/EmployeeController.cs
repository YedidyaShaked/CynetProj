using AutoMapper;
using CovidTracker.DAL;
using CovidTracker.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidTracker.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ICovidTrackerRepo _repo;

        public IMapper _mapper { get; }

        public EmployeeController(ICovidTrackerRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET api/employees
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeReadDto>> GetAllEmployees()
        {
            try
            {
                var employees = _repo.GetAllEmployees();

                return Ok(_mapper.Map<IEnumerable<EmployeeReadDto>>(employees));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return NotFound();
            }
        }

        // GET api/commands{id} 
        [HttpGet("{id}", Name = "GetEmployeeById")]
        public ActionResult<EmployeeReadDto> GetEmployeeById(int id)
        {
            try
            {
                var commandItem = _repo.GetEmployeeById(id);

                if (commandItem == null)
                    return NotFound();

                return Ok(_mapper.Map<EmployeeReadDto>(commandItem));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return NotFound();
            }
        }
    }
}
