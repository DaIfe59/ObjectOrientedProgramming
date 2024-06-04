using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Controllers
{
    //localhost:xxxx/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(dbContext.Employees.ToList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetEmployeeById(int id) 
        {
            var employee = dbContext.Employees.Find(id);

            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary,
            };
            var employeeBuyer = new Buyer()
            {
                //Id= addEmployeeDto.Id,
                Name = addEmployeeDto.Name,
                Summa = 0,
            };

            dbContext.Employees.Add(employeeEntity);
            dbContext.Buyers.Add(employeeBuyer);
            dbContext.SaveChanges();

            return Ok(employeeEntity);
        }


        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateEmployee(int id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = dbContext.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();
            }
            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone= updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;

            var employeeBuyer = dbContext.Buyers.Find(id);
            employeeBuyer.Name = updateEmployeeDto.Name;
            dbContext.SaveChanges();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
           var employeeBuyer = dbContext.Buyers.Find(id);
            dbContext.Employees.Remove(employee);
           dbContext.Buyers.Remove(employeeBuyer);
            dbContext.SaveChanges();

            return Ok();
        }


    }
}
