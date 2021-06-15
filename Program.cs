using EmployeeManagement_day27.Model.SalaryModel;
using System;

namespace EmployeeManagement_day27
{
    class Program
    {
        static void Main(string[] args)
        {
            Salary salary = new Salary();
            SalaryUpdateModel updateModel = new SalaryUpdateModel();
            salary.FindSum();
        }
    }
}
