using EmployeeManagement_day27;
using EmployeeManagement_day27.Model.SalaryModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmployeeManagementTest
{
    [TestClass]
    public class UnitTest1
    {
        //UC3
        [TestMethod]
        public void GivenSalaryDataAbleToUpdateSalaryDetails()
        {
            Salary salary = new Salary();
            SalaryUpdateModel updateModel = new SalaryUpdateModel()
            {
                SalaryId = 1,
                Month = "Jan",
                EmployeeSalary = 1300,
                EmployeeId = 2
            };

            int EmpSalary = salary.UpdateEmployeeSalary(updateModel);
            Assert.AreEqual(updateModel.EmployeeSalary, EmpSalary);
        }

        //UC5
        [TestMethod]
        public void GivenDateRange_ShouldReturnEmployeeName()
        {
            Salary salary = new Salary();
            var Employeename = salary.RetrieveEmployee_BetweenParticularDate();
            Assert.IsTrue(Employeename);
        }
        //UC6
        [TestMethod]
        public void GivenGender_shouldReturnSalarySum()
        {
            Salary salary = new Salary();
            var Employeename = salary.FindSum();
            Assert.IsTrue(Employeename);
        }

        //UC7
       // [TestMethod]
       /* public void AddNewRecord()
        {
            Salary salary = new Salary();
            SalaryDetailModel detailModel = new SalaryDetailModel()
            {

                EmployeeName = "Rusi",
                Gender="F",
                Hire_date=new DateTime(2018,04,09),
                dept_no=3,
                email="rusi@gmail.com",
                birthday=new DateTime(1995,01,29),
                JobDescription="Developer",
                
            };
            var Employeename= salary.AddNewRecord(detailModel);
            Assert.IsTrue(Employeename);
        }
       */
        //UC8
        [TestMethod]
        public void AddNewRecordToBothTables()
        {
            Salary salary = new Salary();
            SalaryDetailModel detailModel = new SalaryDetailModel()
            {

                EmployeeName = "Nitya",
                Gender = "F",
                Hire_date = new DateTime(2019, 06, 09),
                dept_no = 4,
                email = "Nitya@gmail.com",
                birthday = new DateTime(1994, 01, 29),
                JobDescription = "Fullstack Developer",

            };
            var Employeename = salary.InsertEmployeeRecordToBothTables(detailModel);
            Assert.IsTrue(Employeename);
        }
    }
    
}
