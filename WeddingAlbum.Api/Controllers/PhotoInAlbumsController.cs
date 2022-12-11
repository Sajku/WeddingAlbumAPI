using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Commands;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.Api.Controllers
{
    [ApiController]
    public class PhotoInAlbumsController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public PhotoInAlbumsController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [AllowAnonymous]
        [HttpGet("photoInAlbums")]
        public async Task<IActionResult> GetPhotoInAlbums([FromQuery] GetPhotoInAlbumsParameter parameter)
        {
            var response = await _queryDispatcher.Dispatch(parameter);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("photoInAlbums")]
        public async Task<IActionResult> AddPhotoInAlbum([FromBody] AddPhotoInAlbumCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }
    }
}
