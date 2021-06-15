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
        public bool FindSum()
        {
            try
            {
                SalaryDetailModel displayModel = new SalaryDetailModel();


                using (SalaryConnection)
                {
                    SqlCommand command = new SqlCommand("select sum(s.EmpSal) ,e.gender from Salary s inner join Employee1 e on s.empid=e.empid  group by gender ;", SalaryConnection);
                    SalaryUpdateModel updateModel = new SalaryUpdateModel();

                    SalaryConnection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            updateModel.EmployeeSalary = dr.GetDecimal(0);
                            displayModel.Gender = dr.GetString(1);
                            Console.WriteLine(displayModel.Gender + " " + updateModel.EmployeeSalary);

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
        public int UpdateEmployeeSalary(SalaryUpdateModel salaryUpdateModel)
        {
            SqlConnection SalaryConnection = ConnectionSetup();
            int salary = 0;
            try
            {
                using (SalaryConnection)
                {
                    string id = "2";
                   
                    string query = @"select * from Employee where id=" + Convert.ToInt32(id);
                    SalaryDetailModel displayModel = new SalaryDetailModel();
                    SqlCommand command = new SqlCommand("spUpdateEmployeeSalary", SalaryConnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", salaryUpdateModel.SalaryId);
                    command.Parameters.AddWithValue("@month", salaryUpdateModel.Month);
                    command.Parameters.AddWithValue("@salary", salaryUpdateModel.EmployeeSalary);
                    command.Parameters.AddWithValue("@EmpId", salaryUpdateModel.EmployeeId);
                    SalaryConnection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            displayModel.EmployeeId = Convert.ToInt32(dr["EmpId"]);
                            displayModel.EmployeeName = dr["EName"].ToString();
                            displayModel.EmployeeSalary = Convert.ToInt32(dr["EmpSal"]);
                            displayModel.Month = dr["SalaryMonth"].ToString();
                            displayModel.SalaryId = Convert.ToInt32(dr["SalaryId"]);
                            Console.WriteLine(displayModel.EmployeeName + " " + displayModel.EmployeeSalary + " " + displayModel.Month);
                            Console.WriteLine("\n");
                            salary = displayModel.EmployeeSalary;
                        }
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
            return salary;
        }

         public bool  AddNewRecord(SalaryDetailModel displayModel)
         {
            SqlConnection SalaryConnection = ConnectionSetup();
            
            try
            {
                using (SalaryConnection)
                {
                    SqlCommand command = new SqlCommand("spAddingRecord", SalaryConnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmpName",displayModel.EmployeeName);
                    command.Parameters.AddWithValue("@gender", displayModel.Gender);
                    command.Parameters.AddWithValue("@hireday", displayModel.Hire_date);
                    command.Parameters.AddWithValue("@deptNo", displayModel.dept_no);
                    command.Parameters.AddWithValue("@email", displayModel.email);
                    command.Parameters.AddWithValue("@birthdate", displayModel.birthday);
                    command.Parameters.AddWithValue("@job", displayModel.JobDescription);
                    SalaryConnection.Open();
                    
                    var result = command.ExecuteNonQuery();
                    SalaryConnection.Close();
                    if (result != 0)
                    {

                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                SalaryConnection.Close();
            }
            return false;
         }
    }
    
}

