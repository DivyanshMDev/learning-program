using Microsoft.AspNetCore.Mvc;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // Static list to simulate database for Assignment 2
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John Doe", Email = "john@company.com", Department = "IT", Salary = 50000, DateOfJoining = DateTime.Now.AddYears(-2) },
            new Employee { Id = 2, Name = "Jane Smith", Email = "jane@company.com", Department = "HR", Salary = 45000, DateOfJoining = DateTime.Now.AddYears(-1) },
            new Employee { Id = 3, Name = "Mike Johnson", Email = "mike@company.com", Department = "Finance", Salary = 55000, DateOfJoining = DateTime.Now.AddMonths(-6) }
        };

        // GET: api/Employee
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            return Ok(employees);
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound($"Employee with ID {id} not found");

            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Employee> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest("Employee data is required");

            if (string.IsNullOrEmpty(employee.Name) || string.IsNullOrEmpty(employee.Email))
                return BadRequest("Name and Email are required fields");

            // Auto-generate ID
            employee.Id = employees.Any() ? employees.Max(e => e.Id) + 1 : 1;
            employee.DateOfJoining = DateTime.Now;

            employees.Add(employee);

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest("Employee data is required");

            var existingEmployee = employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee == null)
                return NotFound($"Employee with ID {id} not found");

            // Update properties
            existingEmployee.Name = employee.Name;
            existingEmployee.Email = employee.Email;
            existingEmployee.Department = employee.Department;
            existingEmployee.Salary = employee.Salary;

            return Ok(existingEmployee);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound($"Employee with ID {id} not found");

            employees.Remove(employee);
            return Ok($"Employee {employee.Name} deleted successfully");
        }

        // Custom route for getting employees by department
        [HttpGet]
        [Route("GetByDepartment/{department}")]
        [ActionName("GetEmployeesByDepartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Employee>> GetEmployeesByDepartment(string department)
        {
            var departmentEmployees = employees.Where(e =>
                e.Department.ToLower() == department.ToLower()).ToList();
            return Ok(departmentEmployees);
        }

        // Custom route for searching employees by name
        [HttpGet]
        [Route("Search")]
        [ActionName("SearchEmployees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Employee>> SearchEmployees([FromQuery] string name)
        {
            if (string.IsNullOrEmpty(name))
                return Ok(employees);

            var searchResults = employees.Where(e =>
                e.Name.ToLower().Contains(name.ToLower())).ToList();
            return Ok(searchResults);
        }
    }
}
