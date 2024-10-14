using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Interfaces
{
    public interface IStudentService
    {
        void SaveStudent(int id);

        Student GetStudent(int id);
    }
}
