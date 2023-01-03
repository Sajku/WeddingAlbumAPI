using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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

        [SwaggerOperation(Summary = "ZWRACA SZCZEGÓŁY EVENTU", Description = "description")]
        [AllowAnonymous]
        [HttpGet("events/{eventId}")]
        public async Task<IActionResult> GetEventDetails([FromRoute] int eventId, [FromQuery] GetEventDetailsParameter parameter)
        {
            parameter.EventId = eventId;
            return Ok(await _queryDispatcher.Dispatch(parameter));
        }

        [SwaggerOperation(Summary = "ZWRACA PUBLICZNE I PRYWATNE (USERA) ALBUMY W EVENCIE", Description = "description")]
        [AllowAnonymous]
        [HttpGet("events/{eventId}/albums")]
        public async Task<IActionResult> GetEventAlbums([FromRoute] int eventId, [FromQuery] GetEventAlbumsParameter parameter)
        {
            parameter.EventId = eventId;
            return Ok(await _queryDispatcher.Dispatch(parameter));
        }

        [SwaggerOperation(Summary = "ZWRACA WSZYSTKIE ZDJĘCIA W EVENCIE", Description = "description")]
        [AllowAnonymous]
        [HttpGet("events/{eventId}/photos")]
        public async Task<IActionResult> GetEventPhotos([FromRoute] int eventId, [FromQuery] GetEventPhotosParameter parameter)
        {
            parameter.EventId = eventId;
            return Ok(await _queryDispatcher.Dispatch(parameter));
        }

        [SwaggerOperation(Summary = "DODAJE NOWY EVENT", Description = "description")]
        [AllowAnonymous]
        [HttpPost("events")]
        public async Task<IActionResult> AddEvent([FromBody] AddEventCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }

        [SwaggerOperation(Summary = "ZAPISUJE USERA DO EVENTU KODEM ZAPROSZENIA", Description = "description")]
        [AllowAnonymous]
        [HttpPost("events/code")]
        public async Task<IActionResult> AddUserInEventByCode([FromBody] AddUserInEventByCodeCommand command)
        {
            try
            {
                await _commandDispatcher.Dispatch(command);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
