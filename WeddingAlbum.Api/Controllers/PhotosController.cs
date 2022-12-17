using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Commands;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.Api.Controllers
{
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public PhotosController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [AllowAnonymous]
        [HttpGet("photos")]
        public async Task<IActionResult> GetPhotos([FromQuery] GetPhotosParameter parameter)
        {
            var response = await _queryDispatcher.Dispatch(parameter);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("photos")]
        public async Task<IActionResult> AddPhoto([FromBody] AddPhotoCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }



        [AllowAnonymous]
        [HttpGet("photos/albums")]
        public async Task<IActionResult> GetPhotoInAlbum([FromQuery] GetPhotoInAlbumParameter parameter)
        {
            var response = await _queryDispatcher.Dispatch(parameter);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("photos/albums")]
        public async Task<IActionResult> AddPhotoInAlbum([FromBody] AddPhotoInAlbumCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }
    }
}
