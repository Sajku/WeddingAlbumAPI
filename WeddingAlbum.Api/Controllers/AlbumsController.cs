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
    public class AlbumsController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public AlbumsController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [SwaggerOperation(Summary = "ZWRACA ZDJĘCIA W ALBUMIE", Description = "description")]
        [AllowAnonymous]
        [HttpGet("albums/{albumId}/photos")]
        public async Task<IActionResult> GetAlbumPhotos([FromRoute] int albumId, [FromQuery] GetAlbumPhotosParameter parameter)
        {
            parameter.AlbumId = albumId;
            return Ok(await _queryDispatcher.Dispatch(parameter));
        }

        [SwaggerOperation(Summary = "DODAJE NOWY ALBUM", Description = "description")]
        [AllowAnonymous]
        [HttpPost("albums")]
        public async Task<IActionResult> AddAlbum([FromBody] AddAlbumCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }
    }
}
