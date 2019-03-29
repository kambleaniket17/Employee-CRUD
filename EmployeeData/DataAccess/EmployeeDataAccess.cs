namespace EmployeeData.DataAccess
{
    using EmployeeData.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    public class EmployeeDataAccess
    {
        string connectionString = "Data Source=(localDB)\\local;Initial Catalog = Sample; Integrated Security = True";
        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
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

        public int AddEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
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
        public int UpdateEmployee(Employee employee)
        {
           
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
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

        //Get the details of a particular employee  
        public Employee GetEmployeeData(int id)
        {
            Employee employee = new Employee();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
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

        //To Delete the record on a particular employee  
        public int DeleteEmployee(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpId",id);

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