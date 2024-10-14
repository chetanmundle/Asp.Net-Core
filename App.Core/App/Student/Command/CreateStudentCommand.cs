using App.Core.Interfaces;
using App.Core.Models;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Core.App.Student.Command
{
    public class CreateStudentCommand : IRequest<int>    // where IRequest<int> ? int = return type
    {
       public StudentDto student {  get; set; }
    }

    public class CreateStudentCommandHandalar : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IAppDbContext _appDbContext;

        public CreateStudentCommandHandalar(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var model = request.student;

            // set StudentDto to Student
            var student = model.Adapt<Domain.Student>();

            await _appDbContext.Set<Domain.Student>().AddAsync(student);

            await _appDbContext.SaveChangesAsync();

            return student.StudentId;  


        }
    }
}
