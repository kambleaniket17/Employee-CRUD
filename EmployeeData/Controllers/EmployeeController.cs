// -------------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeController.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Aniket Kamble"/>
// ---------------------------------------------------------------------------------------------------------------------------
namespace EmployeeData.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EmployeeData.DataAccess;
    using EmployeeData.Model;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// EmployeeController class
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// The employee data access
        /// </summary>
        private EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>List IEnumerable.</returns>
        [HttpGet]
        [Route("getuser")]
        public IList<Employee> GetData()
        {
             var employees = this.employeeDataAccess.GetAllEmployees().ToList();
             return employees;
        }

        /// <summary>
        /// Adds the data.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>The value</returns>
        [HttpPost]
        [Route("create")]
        public int AddData(Employee employee)
        {
            EmployeeDataAccess dataAccess = new EmployeeDataAccess();
            return dataAccess.AddEmployee(employee);
        }

        /// <summary>
        /// Details the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>List employee.</returns>
        [HttpGet]
        [Route("Details/{id}")]
        public Employee Details(int id)
        {
            EmployeeDataAccess dataAccess = new EmployeeDataAccess();
            return dataAccess.GetEmployeeData(id);
        }

        /// <summary>
        /// Edits the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>The value</returns>
        [HttpPut]
        [Route("Edit")]
        public int Edit(Employee employee)
        {
            EmployeeDataAccess dataAccess = new EmployeeDataAccess();
            return dataAccess.UpdateEmployee(employee);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>value int</returns>
        [HttpDelete]
        [Route("Delete/{id}")]
        public int Delete(int id)
        {
            EmployeeDataAccess dataAccess = new EmployeeDataAccess();
            return dataAccess.DeleteEmployee(id);
        }
    }
}