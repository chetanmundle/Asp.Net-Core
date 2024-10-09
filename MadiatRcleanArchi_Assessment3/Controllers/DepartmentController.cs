using App.Core.App.Department.Command;
using App.Core.App.Department.Query;
using App.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MadiatRcleanArchi_Assessment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly  IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddDepartment(DepartmentDto departmentDto)
        {
            var result = await _mediator.Send(new CreateDepartmentCommand { Department = departmentDto });

            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllDepartment()
        {
            var result = await _mediator.Send(new GetDepartmentQuery());
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var result = await _mediator.Send(new GetDepartmentByIdQuery { DeptID = id });
            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateDepartment(DepartmentDto departmentDto)
        {
            var result = await _mediator.Send(new  UpdateDepartmentCommand { Department = departmentDto });
            return Ok(result);
        }


        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeletedDepartmentById(int id)
        {
            var result = await _mediator.Send(new DeleteDepartmentCommand { DeptId = id });
            return Ok(result);
        }

    }
}
