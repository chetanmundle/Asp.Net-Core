using App.Core.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class StudentServices : IStudentService
    {
        private readonly AppDbContext _dbcontext;

        public StudentServices(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public Student GetStudent(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveStudent(int id)
        {
            throw new NotImplementedException();
        }
    }
}
