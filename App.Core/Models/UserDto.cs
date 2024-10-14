using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Models
{
    public class UserDto
    {
        [Key]
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
