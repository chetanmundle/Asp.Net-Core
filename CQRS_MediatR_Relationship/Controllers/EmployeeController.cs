using App.Core.App.Employee.Command;
using App.Core.App.Employee.Query;
using App.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CQRS_MediatR_Relationship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{id}/get")]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            var emp = await _mediator.Send(new GetEmployeeByIdQuery { EmpId = id });
            return Ok(emp);
        }


        [HttpPost]
        public async Task<IActionResult> SaveEmployee(EmployeeDto empDto)
        {
            var employeeDto = await _mediator.Send(new CreateEmployeeCommand { EmployeeDto = empDto });

            return Ok(employeeDto);
        }

        [HttpGet("all/[action]")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var listOfEmp = await _mediator.Send(new GetEmployeeQuery());

            return Ok(listOfEmp);
        }

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeleteEmployeeByID(int id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand { EmployeeId = id });

            return Ok(result);
        }

        [HttpPut("[action]/put")]
        public async Task<IActionResult> UpdateEmployee(EmployeeDto employeeDto)
        {
            var result = await _mediator.Send(
                new UpdateEmployeeCommand { EmployeeDto= employeeDto });

            return Ok(result);

        }

        
    }
}
