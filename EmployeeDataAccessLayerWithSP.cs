using DemoAdoCrud.Models;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata;
using System.Data;

namespace DemoAdoCrud; 

public class EmployeeDataAccessLayerWithSP
{
    string connString = ConnectionString.GotconnectionString();

    public List<Employee> GetEmployees()
    {
        List<Employee> employees = new List<Employee>();

       using SqlConnection conn = new SqlConnection(connString);

       

         SqlCommand cmd = new SqlCommand("SpGetemp", conn);

        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Employee employee = new Employee();
            
            employee.Id = Convert.ToInt32(reader["Id"]);
            employee.Name = reader["Name"].ToString() ?? string.Empty;
            employee.Age = Convert.ToInt32(reader["Age"]);
            employee.City = reader["City"].ToString() ?? string.Empty;
            employees.Add(employee);
        }
        return employees;
    }

    public void AddEmployee(Employee employee)
    {
        using SqlConnection conn = new SqlConnection(connString);

        SqlCommand cmd = new SqlCommand("SpAddemp", conn);
        cmd.CommandType=CommandType.StoredProcedure;
        
        cmd.Parameters.AddWithValue ("Name", employee.Name);
        cmd.Parameters.AddWithValue("age",employee.Age);
        cmd.Parameters.AddWithValue("city",employee.City);
        conn.Open();
        cmd.ExecuteNonQuery();



    }

    public Employee GetDetails(int id)

    {
        Employee employee = new Employee();
        using SqlConnection conn = new SqlConnection(connString);
       
        SqlCommand cmd = new SqlCommand("SpGetempByid", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@empId", id);

        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
           

            employee.Id = Convert.ToInt32(reader["Id"]);
            employee.Name = reader["Name"].ToString() ?? string.Empty;
            employee.Age = Convert.ToInt32(reader["Age"]);
            employee.City = reader["City"].ToString() ?? string.Empty;
           
        }
        return employee;

    }

    public void UpdateEmployee(Employee employee)
    {
        using SqlConnection conn = new SqlConnection(connString);
       
        SqlCommand cmd = new SqlCommand("SpUpdateEmp", conn);
        cmd.CommandType=CommandType.StoredProcedure;
       
        cmd.Parameters.AddWithValue("@Name", employee.Name);
        cmd.Parameters.AddWithValue("age", employee.Age);
        cmd.Parameters.AddWithValue("city", employee.City);
        cmd.Parameters.AddWithValue("Id", employee.Id);
        conn.Open();
        cmd.ExecuteNonQuery();



    }
    public void DeleteEmployee(int id)
    {
        using SqlConnection conn = new SqlConnection(connString);
       
        SqlCommand cmd = new SqlCommand("SpDeleteEmp", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Id", id);
        conn.Open();
        cmd.ExecuteNonQuery();



    }
}
