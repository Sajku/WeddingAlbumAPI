using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Commands;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.Api.Controllers
{
    [ApiController]
    public class UserFavouriteAlbumsController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public UserFavouriteAlbumsController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [AllowAnonymous]
        [HttpGet("userFavouriteAlbums")]
        public async Task<IActionResult> GetUserFavouriteAlbums([FromQuery] GetUserFavouriteAlbumsParameter parameter)
        {
            var response = await _queryDispatcher.Dispatch(parameter);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("userFavouriteAlbums")]
        public async Task<IActionResult> AddUserFavouriteAlbum([FromBody] AddUserFavouriteAlbumCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }
    }
}
