using App.Core.Interfaces;
using App.Core.Models;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.Apps.Student.Command
{
    public class CreateStudentCommand : IRequest<int>
    {
        public StudentDto Student { get; set; }
    }

    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IAppDbContext _appDbContext;

        public CreateStudentCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var model = request.Student;

            //var student = new Domain.Student
            //{
            //    StudentId = model.StudentId,
            //    FirstName = model.FirstName,
            //    LastName = model.LastName,
            //    //DateOfBith = model.DateOfBith,
            //    StudentCourseMappings = new List<StudentCourseMapping>()
            //};
            var student = model.Adapt<Domain.Student>();

            await _appDbContext.Set<Domain.Student>().AddAsync(student);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return student.StudentId;
        }
    }
}
