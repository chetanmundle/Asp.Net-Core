using App.Core.App.Student.Command;
using App.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Threading.Tasks;
using ValidatorsAndExceptionFilter.Filters;

namespace ValidatorsAndExceptionFilter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IMediator mediator, ILogger<EmployeeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentDto studentDto)
        {
            _logger.LogInformation("Post method");
            var validator = new StudentDtoValidator();
            var result = validator.Validate(studentDto);

            if (!result.IsValid)
            {
                var errorMessage = result.Errors[0].ErrorMessage;
                return BadRequest(errorMessage);
            }

            return Ok(await _mediator.Send(new CreateStudentCommand { EmployeeDto = studentDto }));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ExceptionTest()
        {
            var test = await Task.FromResult(0);
            throw new NotFoundException("Resource Not Found");
     

            //throw new System.Exception("Test");

            return Ok();
        }

    }
}
