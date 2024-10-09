using App.Core;
using Domain;
using System.Linq;

namespace Infrastructure.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _dbContext;
        public StudentService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddStudent(Student student)
        {
            student.StudentCourseMappings
                .Add(new StudentCourseMapping { CourseId = 1 });

            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }

        public Student GetStudent(int id)
        {
            //var test = _dbContext.Students.AsNoTracking().FirstOrDefault(x => x.StudentId == 1);
            //test.FirstName = "testtgsvdshdgshdg";
            //_dbContext.SaveChanges();


            var data = _dbContext.Students.FirstOrDefault(x => x.StudentId == id);

            return data;
        }
    }
}
