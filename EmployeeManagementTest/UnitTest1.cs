using EmployeeManagement_day27;
using EmployeeManagement_day27.Model.SalaryModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeManagementTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenSalaryDataAbleToUpdateSalaryDetails()
        {
            Salary salary = new Salary();
            SalaryUpdateModel updateModel = new SalaryUpdateModel()
            {
                SalaryId = 1,
                Month = "Jan",
                EmployeeSalary = 1400,
                EmployeeId = 2
            };

            int EmpSalary = salary.UpdateEmployeeSalary(updateModel);

            Assert.AreEqual(updateModel.EmployeeSalary, EmpSalary);
        }
    }

}
