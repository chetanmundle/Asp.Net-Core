﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Models.Api
{
    public class LoginRequestModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
