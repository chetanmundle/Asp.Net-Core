using App.Core.App.Student.Command;
using App.Core.App.Student.Query;
using App.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRSandMedeatr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsCQRSController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsCQRSController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [HttpPost]
        public async Task<IActionResult> Post(StudentDto model)
        {
            var studentId = await _mediator.Send(new CreateStudentCommand { student = model });
            return Ok(studentId);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var studnets =  await _mediator.Send(new GetStudentQuery());
            return Ok(studnets);
        }
    }
}
