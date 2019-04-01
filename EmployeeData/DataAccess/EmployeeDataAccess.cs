// -------------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeDataAccess.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Aniket Kamble"/>
// ---------------------------------------------------------------------------------------------------------------------------
namespace EmployeeData.DataAccess
{
    using System;
    using EmployeeData.Model;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// EmployeeDataAccess class
    /// </summary>
    /// <seealso cref="Object" />
    public class EmployeeDataAccess
    {
        /// <summary>
        /// The connection string
        /// </summary>
        string connectionString = "Data Source=(localDB)\\local;Initial Catalog = Sample; Integrated Security = True";

        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns>List IEnumerable.</returns>
        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("spGetAllEmployees", connection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmployeeId = Convert.ToInt32(sqlDataReader["EmployeeId"]);
                        employee.Name = sqlDataReader["Name"].ToString();
                        employee.City = sqlDataReader["City"].ToString();
                        employee.Department = sqlDataReader["Department"].ToString();
                        employee.Gender = sqlDataReader["Gender"].ToString();
                        employees.Add(employee);
                    }

                    connection.Close();
                }

                return employees;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>value int</returns>
        public int AddEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(this.connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("spAddEmployee", connection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@name", employee.Name);
                    sqlCommand.Parameters.AddWithValue("@City", employee.City);
                    sqlCommand.Parameters.AddWithValue("@Department", employee.Department);
                    sqlCommand.Parameters.AddWithValue("@Gender", employee.Gender);
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }

                return 1;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>value int</returns>
        public int UpdateEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpId", employee.EmployeeId);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@City", employee.City);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                return 1;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Get the details of a particular employee  
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>List Employee</returns>
        public Employee GetEmployeeData(int id)
        {
            Employee employee = new Employee();

            try
            {
                using (SqlConnection con = new SqlConnection(this.connectionString))
                {
                    string sqlQuery = "SELECT * FROM tblEmployee WHERE EmployeeId= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.Department = rdr["Department"].ToString();
                        employee.City = rdr["City"].ToString();
                    }
                }

                return employee;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        ///  To Delete the record on a particular employee  
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>value int</returns>
        public int DeleteEmployee(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}