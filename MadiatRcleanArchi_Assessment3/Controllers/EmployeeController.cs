using App.Core.App.Employee.Command;
using App.Core.App.Employee.Query;
using App.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MadiatRcleanArchi_Assessment3.Controllers
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

        // Api for Save Employee
        [HttpPost("[action]")]
        public async Task<IActionResult> AddEmployee(EmployeeDto employeeDto)
        {
            var result = await _mediator.Send(new CreateEmployeeCommand { EmployeeDto = employeeDto});

            return Ok(result);
        }

        // Api for Get All Employees with Department
        [HttpGet("[action]")]
        public async Task<IActionResult> GetEmployeesWithDepartment()
        {
            var result = await _mediator.Send(new GetEmployeeWithDepartmentQuery());
            return Ok(result);
        }

        // Api for Get Single Employee with Department
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetEmpByIdWithDepartment(int id)
        {
            var result = await _mediator.Send(new GetEmpByIdWithDepartment() { EmpId = id });
            return Ok(result);
        }

       
        // Api for update Employee
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateEmployee(EmployeeDto employeeDto)
        {
            var result = await _mediator.Send(new UpdateEmployeeCommand { EmployeeDto = employeeDto });
            return Ok(result);
        }
           

        // Api for Delete employee
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _mediator.Send(new  DeleteEmployeeCommand { EmployeeId = id });
            return Ok(result);
        }

        // Api for get Employee with Department
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var retsultlist = await _mediator.Send(new GetEmployeesQuery());
            return Ok(retsultlist);
        }

        // Api for Get Single Employee without Department
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var result = await _mediator.Send(new GetEmployeeByIdQuery { Empid = id });
            return Ok(result);
        }



    }
}
