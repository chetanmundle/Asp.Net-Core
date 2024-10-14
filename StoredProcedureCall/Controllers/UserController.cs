using App.Core.App.User.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace StoredProcedureCall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetUsersQuery()));
        }

        [HttpGet("/twoResultSetSPCall")]
        public async Task<IActionResult> CallSp()
        {
            return Ok(await _mediator.Send(new GetSepreateUserAndDepartment()));
        }
    }
}
