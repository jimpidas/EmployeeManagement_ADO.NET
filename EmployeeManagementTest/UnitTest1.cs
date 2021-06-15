using EmployeeManagement_day27;
using EmployeeManagement_day27.Model.SalaryModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
