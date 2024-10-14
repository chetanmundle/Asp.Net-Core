﻿using App.Core.App.Employee.Command;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(mfg =>
            {
                mfg.RegisterServicesFromAssemblyContaining<CreateEmployeeCommand>();

            });

            return services;
        }
    }
}
