using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Commands;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.Api.Controllers
{
    [ApiController]
    public class UserInEventsController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public UserInEventsController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [AllowAnonymous]
        [HttpGet("userInEvents")]
        public async Task<IActionResult> GetUserInEvents([FromQuery] GetUserInEventsParameter parameter)
        {
            var response = await _queryDispatcher.Dispatch(parameter);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("userInEvents")]
        public async Task<IActionResult> AddUserInEvent([FromBody] AddUserInEventCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }
    }
}
