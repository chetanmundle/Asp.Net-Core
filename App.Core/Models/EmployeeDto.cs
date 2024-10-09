using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Models
{
    public class EmployeeDto
    {
        public int Eid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Salary { get; set; }

        public int DepId { get; set; }

    }
}
