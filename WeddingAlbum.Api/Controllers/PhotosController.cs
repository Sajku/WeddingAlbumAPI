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
    public class PhotosController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public PhotosController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [SwaggerOperation(Summary = "ZWRACA SZCZEGÓŁY ZDJĘCIA", Description = "description")]
        [AllowAnonymous]
        [HttpGet("photos/{photoId}")]
        public async Task<IActionResult> GetPhotoDetails([FromRoute] int photoId, [FromQuery] GetPhotoDetailsParameter parameter)
        {
            parameter.PhotoId = photoId;
            var response = await _queryDispatcher.Dispatch(parameter);
            return Ok(response);
        }

        [SwaggerOperation(Summary = "ZWRACA KOMENTARZE ZDJĘCIA", Description = "description")]
        [AllowAnonymous]
        [HttpGet("photos/{photoId}/comments")]
        public async Task<IActionResult> GetPhotoComments([FromRoute] int photoId, [FromQuery] GetPhotoCommentsParameter parameter)
        {
            parameter.PhotoId = photoId;
            var response = await _queryDispatcher.Dispatch(parameter);
            return Ok(response);
        }

        [SwaggerOperation(Summary = "DODAJE ZDJĘCIE ZROBIONE PRZEZ USERA", Description = "description")]
        [AllowAnonymous]
        [HttpPost("photos")]
        public async Task<IActionResult> AddPhoto([FromBody] AddPhotoCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }

        [SwaggerOperation(Summary = "DODAJE ZDJĘCIE DO ALBUMU", Description = "description")]
        [AllowAnonymous]
        [HttpPost("photos/albums")]
        public async Task<IActionResult> AddPhotoInAlbum([FromBody] AddPhotoInAlbumCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }
    }
}
