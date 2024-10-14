using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Models.Email
{
    public class EmailRequestDto
    {
        public string ToEmail { get; set; }

        public string Username { get; set; }
        
        public string Subject { get; set; }

        public string Message { get; set; }


    }
}
