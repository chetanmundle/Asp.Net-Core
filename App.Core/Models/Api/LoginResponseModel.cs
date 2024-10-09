using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Models.Api
{
    public class LoginResponseModel
    {
        public string UserName { get; set; }

        public string AccessToken { get; set; }

        public int ExpiresIn { get; set; }
    }
}
