using EmployeeAdminPortal.data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    // localhost:port/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // CRUD Operations

        private readonly ApplicationDbContext dbContext;

        // constuctor
        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            // the variable stores a list of all 'Employees' from the dbContext
            var allEmployees = dbContext.Employees.ToList();
            return Ok(allEmployees); // response 200

        }

        // Code to retrieve a specific employee only by ID

        [HttpGet]
        [Route("{id:guid}")] // setting the id as as the route parameter
        public IActionResult GetEmployeesbyId(Guid id) //mapping the route param with func param
        {
            var emp = dbContext.Employees.Find(id);
            if(emp is null)
            {
                return NotFound();
            }
            return Ok(emp);

        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new Employee
            {
                // Id field of the entity is handled by the entityframeworkcore itself.
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };
            dbContext.Employees.Add(employeeEntity);
            // only save changes will reflect the changes to the db
            dbContext.SaveChanges();
            return Ok(employeeEntity); //response 200
        }


        // UPDATE OPERATION

        [HttpPut]
        [Route("{id:guid}")]

        public IActionResult UpdateEmployee(Guid id,UpdateEmployeeDto updateEmployeeDto)
        {
            var emp = dbContext.Employees.Find(id); // find the entry to be updated
            if(emp is null) {
                return NotFound();
            }

            //update the values of the found entity with that of the DTO
            emp.Name = updateEmployeeDto.Name;
            emp.Email = updateEmployeeDto.Email;        
            emp.Phone = updateEmployeeDto.Phone;
            emp.Salary = updateEmployeeDto.Salary;

            dbContext.SaveChanges();
    }
}
