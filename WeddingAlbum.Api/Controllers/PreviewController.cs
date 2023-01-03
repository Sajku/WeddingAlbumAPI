using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Queries;

namespace WeddingAlbum.Api.Controllers
{
    [ApiController]
    public class PreviewController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public PreviewController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [SwaggerOperation(Summary = "ZWRACA WSZYSTKICH USERÓW", Description = "description")]
        [AllowAnonymous]
        [HttpGet("users/all")]
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersParameter parameter)
        {
            var response = await _queryDispatcher.Dispatch(parameter);
            return Ok(response);
        }

        [SwaggerOperation(Summary = "ZWRACA WSZYSTKICH USEROW WE WSZYSTKICH EVENTACH", Description = "description")]
        [AllowAnonymous]
        [HttpGet("users/events/all")]
        public async Task<IActionResult> GetUserInEvents([FromQuery] GetUserInEventsParameter parameter)
        {
            var response = await _queryDispatcher.Dispatch(parameter);
            return Ok(response);
        }

        [SwaggerOperation(Summary = "ZWRACA WSZYSTKIE ULUBIONE ALBUMY WSZYSTKICH USEROW", Description = "description")]
        [AllowAnonymous]
        [HttpGet("users/albums/all")]
        public async Task<IActionResult> GetUserFavouriteAlbums([FromQuery] GetUserFavouriteAlbumsParameter parameter)
        {
            var response = await _queryDispatcher.Dispatch(parameter);
            return Ok(response);
        }

        [SwaggerOperation(Summary = "ZWRACA WSZYSTKIE ZDJĘCIA", Description = "description")]
        [AllowAnonymous]
        [HttpGet("photos/all")]
        public async Task<IActionResult> GetPhotos([FromQuery] GetPhotosParameter parameter)
        {
            var response = await _queryDispatcher.Dispatch(parameter);
            return Ok(response);
        }

        [SwaggerOperation(Summary = "ZWRACA WSZYSTKIE ZDJĘCIA WE WSZYSTKICH ALBUMACH", Description = "description")]
        [AllowAnonymous]
        [HttpGet("photos/albums/all")]
        public async Task<IActionResult> GetPhotoInAlbum([FromQuery] GetPhotoInAlbumParameter parameter)
        {
            var response = await _queryDispatcher.Dispatch(parameter);
            return Ok(response);
        }

        [SwaggerOperation(Summary = "ZWRACA WSZYSTKIE EVENTY", Description = "description")]
        [AllowAnonymous]
        [HttpGet("events/all")]
        public async Task<IActionResult> GetEvents([FromQuery] GetEventsParameter parameter)
        {
            var response = await _queryDispatcher.Dispatch(parameter);
            return Ok(response);
        }

        [SwaggerOperation(Summary = "ZWRACA WSZYSTKIE KOMENTARZE", Description = "description")]
        [AllowAnonymous]
        [HttpGet("comments/all")]
        public async Task<IActionResult> GetComments([FromQuery] GetCommentsParameter parameter)
        {
            var response = await _queryDispatcher.Dispatch(parameter);
            return Ok(response);
        }


        [SwaggerOperation(Summary = "ZWRACA WSZYSTKIE ALBUMY", Description = "description")]
        [AllowAnonymous]
        [HttpGet("albums/all")]
        public async Task<IActionResult> GetAlbums([FromQuery] GetAlbumsParameter parameter)
        {
            var response = await _queryDispatcher.Dispatch(parameter);
            return Ok(response);
        }
    }
}
