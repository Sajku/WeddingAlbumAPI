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
    public class UsersController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public UsersController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [SwaggerOperation(Summary = "REJESTRACJA NOWEGO USERA", Description = "description")]
        [AllowAnonymous]
        [HttpPost("users/register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }

        [SwaggerOperation(Summary = "LOGOWANIE USERA - ZWRACA TOKEN", Description = "description")]
        [AllowAnonymous]
        [HttpGet("users/login")]
        public async Task<IActionResult> LoginUser([FromQuery] LoginUserParameter parameter)
        {
            return Ok(await _queryDispatcher.Dispatch(parameter));
        }

        [SwaggerOperation(Summary = "ZWRACA WSZYSTKIE EVENTY USERA", Description = "description")]
        [AllowAnonymous]
        [HttpGet("users/events")]
        public async Task<IActionResult> GetUserEvents([FromQuery] GetUserEventsParameter parameter)
        {
            return Ok(await _queryDispatcher.Dispatch(parameter));
        }

        [SwaggerOperation(Summary = "ZWRACA ULUBIONE ALBUMY USERA W DANYM EVENCIE", Description = "description")]
        [AllowAnonymous]
        [HttpGet("users/albums/fav")]
        public async Task<IActionResult> GetUserFavouriteAlbumsInEvent([FromQuery] GetUserFavouriteAlbumsInEventParameter parameter)
        {
            return Ok(await _queryDispatcher.Dispatch(parameter));
        }

        [SwaggerOperation(Summary = "ZWRACA ZDJĘCIA USERA W DANYM EVENCIE", Description = "description")]
        [AllowAnonymous]
        [HttpGet("users/photos/{eventId}")]
        public async Task<IActionResult> GetUserPhotosInEvent([FromRoute] int eventId, [FromQuery] GetUserPhotosInEventParameter parameter)
        {
            parameter.EventId = eventId;
            return Ok(await _queryDispatcher.Dispatch(parameter));
        }

        [SwaggerOperation(Summary = "(TEMP) DODAJE USERA DO EVENTU NA SZTYWNO - BEZ KODU ZAPROSZENIA", Description = "description")]
        [AllowAnonymous]
        [HttpPost("users/events")]
        public async Task<IActionResult> AddUserInEvent([FromBody] AddUserInEventCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }

        [SwaggerOperation(Summary = "DODAJE ALBUM DO ULUBIONYCH ALBUMÓW USERA", Description = "description")]
        [AllowAnonymous]
        [HttpPost("users/albums/fav")]
        public async Task<IActionResult> AddUserFavouriteAlbum([FromBody] AddUserFavouriteAlbumCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }

        [SwaggerOperation(Summary = "USUWA ALBUM Z ULUBIONYCH ALBUMÓW USERA", Description = "description")]
        [AllowAnonymous]
        [HttpDelete("users/albums/fav")]
        public async Task<IActionResult> DeleteUserFavouriteAlbum([FromBody] DeleteUserFavouriteAlbumCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }
    }
}
