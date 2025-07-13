using Microsoft.AspNetCore.Mvc;
using WebApi4.Models;

namespace WebApi4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // Hardcoded employee data (as required by assignment)
        private static List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "John Doe",
                Email = "john@company.com",
                Department = "IT",
                Salary = 50000,
                DateOfJoining = DateTime.Now.AddYears(-2),
                IsActive = true
            },
            new Employee
            {
                Id = 2,
                Name = "Jane Smith",
                Email = "jane@company.com",
                Department = "HR",
                Salary = 45000,
                DateOfJoining = DateTime.Now.AddYears(-1),
                IsActive = true
            },
            new Employee
            {
                Id = 3,
                Name = "Mike Johnson",
                Email = "mike@company.com",
                Department = "Finance",
                Salary = 55000,
                DateOfJoining = DateTime.Now.AddMonths(-6),
                IsActive = false
            }
        };

        // GET: api/Employee
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return Ok(employees);
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

        // POST: api/Employee (Create operation)
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest("Employee data is required");

            // Validate required fields
            if (string.IsNullOrEmpty(employee.Name))
                return BadRequest("Employee name is required");

            if (string.IsNullOrEmpty(employee.Email))
                return BadRequest("Employee email is required");

            // Auto-generate ID
            employee.Id = employees.Any() ? employees.Max(e => e.Id) + 1 : 1;
            employee.DateOfJoining = DateTime.Now;
            employee.IsActive = true;

            employees.Add(employee);

            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        // PUT: api/Employee/5 (Update operation - MAIN FOCUS OF ASSIGNMENT 4)
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Employee> Put(int id, [FromBody] Employee employee)
        {
            // Check if the id value is lesser than or equal to 0
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            // Check if the employee exists in the hardcoded list
            var existingEmployee = employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
            {
                return BadRequest("Invalid employee id");
            }

            // Validate input data
            if (employee == null)
                return BadRequest("Employee data is required");

            if (string.IsNullOrEmpty(employee.Name))
                return BadRequest("Employee name is required");

            if (string.IsNullOrEmpty(employee.Email))
                return BadRequest("Employee email is required");

            // Update the existing employee with new data from JSON body
            existingEmployee.Name = employee.Name;
            existingEmployee.Email = employee.Email;
            existingEmployee.Department = employee.Department;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.IsActive = employee.IsActive;
            // Keep original DateOfJoining and Id

            // Return the updated employee data as ActionResult
            return Ok(existingEmployee);
        }

        // DELETE: api/Employee/5 (Delete operation)
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            // Check if the id value is lesser than or equal to 0
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            // Check if the employee exists in the hardcoded list
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return BadRequest("Invalid employee id");
            }

            employees.Remove(employee);
            return Ok($"Employee {employee.Name} deleted successfully");
        }
    }
}
