using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [ActionName("GetEmployeeByID")]
        public Models.User Get(int id)
        {
            //return listEmp.First(e => e.ID == id);  
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=.\SHEKHARBE-2K16;Database=Demo;User ID=sa;Password=cybage@123;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from User where EmployeeId=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            Models.User emp = null;
            while (reader.Read())
            {
                emp = new Models.User();
                emp.userId = Convert.ToInt32(reader.GetValue(0));
                emp.firstName = reader.GetValue(1).ToString();
                emp.lastName = reader.GetValue(1).ToString();
                emp.address = reader.GetValue(1).ToString();
                emp.city = reader.GetValue(1).ToString();
                emp.state = reader.GetValue(1).ToString();
                emp.email = reader.GetValue(1).ToString();
                emp.gender = reader.GetValue(1).ToString();
            }
            myConnection.Close();
            return emp;
        }

        [HttpPost]
        public void AddEmployee(Models.User employee)
        {
            //int maxId = listEmp.Max(e => e.ID);  
            //employee.ID = maxId + 1;  
            //listEmp.Add(employee);  

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Data Source=SHEKHARBE-2K16;Initial Catalog=Demo;Integrated Security=SSPI;User ID=sa;Password=cybage@123;";
            //SqlCommand sqlCmd = new SqlCommand("INSERT INTO tblEmployee (EmployeeId,Name,ManagerId) Values (@EmployeeId,@Name,@ManagerId)", myConnection);  
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO [db_owner].[User] ([userId],[firstName],[lastName],[address],[city],[state],[email],[gender]) VALUES(@userId,@firstName,@lastName,@address,@city,@state,@email,@gender)";
            sqlCmd.Connection = myConnection;

            sqlCmd.Parameters.AddWithValue("@userId", Guid.NewGuid().ToString("N"));
            sqlCmd.Parameters.AddWithValue("@firstName", employee.firstName);
            sqlCmd.Parameters.AddWithValue("@lastName", employee.lastName);
            sqlCmd.Parameters.AddWithValue("@address", employee.address);
            sqlCmd.Parameters.AddWithValue("@city", employee.city);
            sqlCmd.Parameters.AddWithValue("@state", employee.state);
            sqlCmd.Parameters.AddWithValue("@email", employee.email);
            sqlCmd.Parameters.AddWithValue("@gender", employee.gender);
            myConnection.Open();
            int rowInserted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }

        [HttpPut]
        public void EditEmployee(Models.User employee)
        {
            //int maxId = listEmp.Max(e => e.ID);  
            //employee.ID = maxId + 1;  
            //listEmp.Add(employee);  

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Data Source=SHEKHARBE-2K16;Initial Catalog=Demo;Integrated Security=SSPI;User ID=sa;Password=cybage@123;";
            //SqlCommand sqlCmd = new SqlCommand("INSERT INTO tblEmployee (EmployeeId,Name,ManagerId) Values (@EmployeeId,@Name,@ManagerId)", myConnection);  
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE [db_owner].[User]SET[firstName] = @firstName,[lastName] = @lastName,[address] = @address,[city] = @city,[state] = @state,[email] = @email,[gender] = @gender WHERE [userId] = @userId";
            sqlCmd.Connection = myConnection;
            
            sqlCmd.Parameters.AddWithValue("@firstName", employee.firstName);
            sqlCmd.Parameters.AddWithValue("@lastName", employee.lastName);
            sqlCmd.Parameters.AddWithValue("@address", employee.address);
            sqlCmd.Parameters.AddWithValue("@city", employee.city);
            sqlCmd.Parameters.AddWithValue("@state", employee.state);
            sqlCmd.Parameters.AddWithValue("@email", employee.email);
            sqlCmd.Parameters.AddWithValue("@gender", employee.gender);
            myConnection.Open();
            int rowInserted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }

        [ActionName("DeleteEmployee")]
        public void DeleteEmployeeByID(int id)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=.\SHEKHARBE-2K16;Database=Demo;User ID=sa;Password=cybage@123;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "delete from User where userId=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            int rowDeleted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }
    }
}
