using EmployeeManagement_day27.Model.SalaryModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace EmployeeManagement_day27
{
    public class Salary
    {
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=payroll_service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        SqlConnection SalaryConnection = ConnectionSetup();
        public bool RetrieveEmployee_BetweenParticularDate()
        {
            try
            {
                SalaryDetailModel displayModel = new SalaryDetailModel();
                
            
                using (SalaryConnection)
                {
                    SqlCommand command = new SqlCommand("select ename from Employee1 where HireDay between '2017-03-03' and getdate();", SalaryConnection);
                    
                    
                    SalaryConnection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            displayModel.EmployeeName = dr.GetString(0);
                            Console.WriteLine(displayModel.EmployeeName);
                            
                        }
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                SalaryConnection.Close();
            }
            return false;
        }
        
    }
}
