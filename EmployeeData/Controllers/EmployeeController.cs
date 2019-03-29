namespace EmployeeData.Controllers
{
    using EmployeeData.Model;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EmployeeData.DataAccess;

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();

        [HttpGet]
        [Route("getuser")]
        public IEnumerable<Employee> GetData()
        {
            
            return employeeDataAccess.GetAllEmployees();
        }

        [HttpPost]
        [Route("create")]
        public int AddData(Employee employee)
        {
            EmployeeDataAccess dataAccess = new EmployeeDataAccess();


            return dataAccess.AddEmployee(employee);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public Employee Details(int id)
        {
            EmployeeDataAccess dataAccess = new EmployeeDataAccess();
            return dataAccess.GetEmployeeData(id);
        }

        [HttpPut]
        [Route("Edit")]
        public int Edit(Employee employee)
        {
            EmployeeDataAccess dataAccess = new EmployeeDataAccess();
            return dataAccess.UpdateEmployee(employee);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public int Delete(int id)
        {
            EmployeeDataAccess dataAccess = new EmployeeDataAccess();
            return dataAccess.DeleteEmployee(id);
        }
    }
}