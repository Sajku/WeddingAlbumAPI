using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Commands;
using WeddingAlbum.PublishedLanguage.Queries;

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

        [AllowAnonymous]
        [HttpGet("comments")]
        public async Task<IActionResult> GetComments([FromQuery] GetCommentsParameter parameter)
        {
            var response = await _queryDispatcher.Dispatch(parameter);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("comments")]
        public async Task<IActionResult> AddEvent([FromBody] AddCommentCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }
    }
}
