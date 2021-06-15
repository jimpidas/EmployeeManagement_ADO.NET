using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement_day27.Model.SalaryModel
{
    public class SalaryDetailModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string JobDescription { get; set; }
        public string Month { get; set; }
        public int EmployeeSalary { get; set; }
        public int SalaryId { get; set; }
        public string Gender { get; set; }
       public DateTime Hire_date { get; set; }
        public string email { get; set; }
        public int dept_no { get; set; }
        public DateTime birthday { get; set; }

    }
}
