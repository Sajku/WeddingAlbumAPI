using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Commands;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.Api.Controllers
{
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public EventsController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [AllowAnonymous]
        [HttpGet("events")]
        public async Task<IActionResult> GetEvents([FromQuery] GetEventsParameter parameter)
        {
            var response = await _queryDispatcher.Dispatch(parameter);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("events")]
        public async Task<IActionResult> AddEvent([FromBody] AddEventCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }
    }
}
