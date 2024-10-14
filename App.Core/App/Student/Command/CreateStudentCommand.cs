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
    public class CreateStudentCommand : IRequest<StudentDto>
    {
        public StudentDto EmployeeDto { get; set; }
    }

    public class CreateStudentCommandHadler : IRequestHandler<CreateStudentCommand, StudentDto>
    {
        private readonly IAppDbContext _appDbContext;

        public CreateStudentCommandHadler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<StudentDto> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var model = request.EmployeeDto;

            var student = model.Adapt<Domain.Student>();

            await _appDbContext.Set<Domain.Student>().AddAsync(student);

            await _appDbContext.SaveChangesAsync();

            return student.Adapt<StudentDto>();

        }
    }
}
