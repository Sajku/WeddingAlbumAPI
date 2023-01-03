using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Commands;

namespace WeddingAlbum.Api.Controllers
{
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public CommentController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [SwaggerOperation(Summary = "DODAJE NOWY KOMENTARZ DO ZDJĘCIA", Description = "description")]
        [AllowAnonymous]
        [HttpPost("comments")]
        public async Task<IActionResult> AddComment([FromBody] AddCommentCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }
    }
}
