using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement_day27.Model.SalaryModel
{
    public class SalaryUpdateModel
    {
        public int salaryId;

        public int SalaryId { get; set; }
        public string Month { get; set; }
        public decimal EmployeeSalary { get; set; }
        public int EmployeeId { get; set; }
    }


}
