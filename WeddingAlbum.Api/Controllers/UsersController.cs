using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [AllowAnonymous]
        [HttpPost("users/register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("users/login")]
        public async Task<IActionResult> LoginUser([FromQuery] LoginUserParameter parameter)
        {
            return Ok(await _queryDispatcher.Dispatch(parameter));
        }



        [AllowAnonymous]
        [HttpGet("users/events")]
        public async Task<IActionResult> GetUserInEvents([FromQuery] GetUserInEventsParameter parameter)
        {
            var response = await _queryDispatcher.Dispatch(parameter);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("users/events")]
        public async Task<IActionResult> AddUserInEvent([FromBody] AddUserInEventCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }



        [AllowAnonymous]
        [HttpGet("users/albums")]
        public async Task<IActionResult> GetUserFavouriteAlbums([FromQuery] GetUserFavouriteAlbumsParameter parameter)
        {
            var response = await _queryDispatcher.Dispatch(parameter);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("users/albums")]
        public async Task<IActionResult> AddUserFavouriteAlbum([FromBody] AddUserFavouriteAlbumCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }
    }
}
