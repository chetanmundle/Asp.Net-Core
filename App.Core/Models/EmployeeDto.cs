using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Models
{
    public class EmployeeDto
    {
        public int EmpId { get; set; }

        public string EmpName { get; set; }

        public int EmpSalary { get; set; }

    }
}
