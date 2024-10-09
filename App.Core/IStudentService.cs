using Domain;

namespace App.Core
{
    public interface IStudentService
    {
        void AddStudent(Student student);
        Student GetStudent(int id);
    }
}
