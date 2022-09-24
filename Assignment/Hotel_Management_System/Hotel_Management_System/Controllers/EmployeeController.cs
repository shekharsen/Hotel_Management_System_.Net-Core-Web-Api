using Hotel_Management_System.Data_Access_Layer;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext dbContext;

        public EmployeeController(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            return Ok(dbContext.Employees.ToList());
        }

        [HttpGet]
        [Route("{employeeid:guid}")]
        public IActionResult GetSingleEmployee([FromRoute] Guid employeeid)
        {
            var employee1 = dbContext.Employees.Find(employeeid);

            if (employee1 != null)
            {
                return Ok(employee1);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployee addEmployee)
        {
            var employee = new Employee()
            {
                employee_address = addEmployee.employee_address,
                employee_name = addEmployee.employee_name,
                employee_age = addEmployee.employee_age,
                employee_designation = addEmployee.employee_designation,
                employee_email = addEmployee.employee_email,
                employee_number = addEmployee.employee_number,
                employee_password = addEmployee.employee_password,
                employee_salary = addEmployee.employee_salary
            };

            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();

            return Ok(employee);
        }

        [HttpPut]
        [Route("{employeeid:guid}")]
        public IActionResult UpdateEmployee([FromRoute] Guid employeeid,UpdateEmployee updateEmployee)
        {
            var employee1 = dbContext.Employees.Find(employeeid);
            if (employee1 != null)
            {
                employee1.employee_email = updateEmployee.employee_email;
                employee1.employee_number = updateEmployee.employee_number;
                employee1.employee_password = updateEmployee.employee_password;
                employee1.employee_salary = updateEmployee.employee_salary;
                employee1.employee_address = updateEmployee.employee_address;
                employee1.employee_name = updateEmployee.employee_name;
                employee1.employee_age = updateEmployee.employee_age;
                employee1.employee_designation = updateEmployee.employee_designation;

                dbContext.SaveChanges();

                return Ok(employee1);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{employeeid:guid}")]
        public IActionResult DeleteEmployee([FromRoute] Guid employeeid)
        {
            var employee2 = dbContext.Employees.Find(employeeid);
            if (employee2 != null)
            { 
                dbContext.Employees.Remove(employee2);
                dbContext.SaveChanges();

                return Ok(employee2);
            }

            return NotFound();
        }

    }
}
