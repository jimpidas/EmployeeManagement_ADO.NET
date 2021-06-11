using EmployeeManagement_day27;
using EmployeeManagement_day27.Model.SalaryModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeManagementTest
{
    [TestClass]
    public class UnitTest1
    {
        //UC5
        [TestMethod]
        public void GivenDateRange_ShouldReturnEmployeeName()
        {
            Salary salary = new Salary();
            var Employeename = salary.RetrieveEmployee_BetweenParticularDate();
            Assert.IsTrue(Employeename);
        }  
    }
}
