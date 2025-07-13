using Microsoft.AspNetCore.Mvc;
using WebApi3.Filters;
using WebApi3.Models;

namespace WebApi3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [CustomAuthFilter]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees;

        // Constructor: Create few records
        public EmployeeController()
        {
            if (employees == null)
            {
                employees = GetStandardEmployeeList();
            }
        }

        // Private method GetStandardEmployeeList
        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John Doe",
                    Salary = 50000,
                    Permanent = true,
                    DateOfBirth = new DateTime(1990, 5, 15),
                    Department = new Department { Id = 1, Name = "IT", Description = "Information Technology" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "C#", Level = "Advanced" },
                        new Skill { Id = 2, Name = "ASP.NET", Level = "Intermediate" }
                    }
                },
                new Employee
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Salary = 45000,
                    Permanent = false,
                    DateOfBirth = new DateTime(1992, 8, 22),
                    Department = new Department { Id = 2, Name = "HR", Description = "Human Resources" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 3, Name = "Communication", Level = "Advanced" },
                        new Skill { Id = 4, Name = "Leadership", Level = "Intermediate" }
                    }
                },
                new Employee
                {
                    Id = 3,
                    Name = "Mike Johnson",
                    Salary = 55000,
                    Permanent = true,
                    DateOfBirth = new DateTime(1988, 12, 10),
                    Department = new Department { Id = 3, Name = "Finance", Description = "Financial Management" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 5, Name = "Excel", Level = "Advanced" },
                        new Skill { Id = 6, Name = "Financial Analysis", Level = "Advanced" }
                    }
                }
            };
        }

        // GET: api/Employee (Modified return type to List<Employee>)
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Employee>> Get()
        {
            // Throw exception for testing (as required)
            if (employees.Count == 0)
            {
                throw new InvalidOperationException("No employees found in the system");
            }

            return Ok(employees);
        }

        // GET: api/Employee/Standard
        [HttpGet("Standard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Employee>> GetStandard()
        {
            return Ok(GetStandardEmployeeList());
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Employee> Get(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest("Employee data is required");

            employee.Id = employees.Any() ? employees.Max(e => e.Id) + 1 : 1;
            employees.Add(employee);

            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put(int id, [FromBody] Employee employee)
        {
            var existingEmployee = employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
                return NotFound();

            existingEmployee.Name = employee.Name;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.Permanent = employee.Permanent;
            existingEmployee.Department = employee.Department;
            existingEmployee.Skills = employee.Skills;
            existingEmployee.DateOfBirth = employee.DateOfBirth;

            return Ok(existingEmployee);
        }
    }
}
