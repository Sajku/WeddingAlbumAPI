using System.Collections.Generic;
using System.Threading.Tasks;
using EnsureThat;
using WeddingAlbum.Common.Auth;
using WeddingAlbum.Common.CQRS;
using WeddingAlbum.PublishedLanguage.Commands;
using WeddingAlbum.PublishedLanguage.Dtos;
using WeddingAlbum.PublishedLanguage.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WeddingAlbum.Api.Controllers
{
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public ValuesController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            EnsureArg.IsNotNull(queryDispatcher, nameof(queryDispatcher));
            EnsureArg.IsNotNull(commandDispatcher, nameof(commandDispatcher));

            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [Authorize(Policy = "user")]
        [HttpGet("samples")]
        public async Task<IActionResult> GetSamples([FromQuery] SampleParameter parameter)
        {
            List<SampleDTO> result = await _queryDispatcher.Dispatch(parameter);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("samples")]
        public async Task<IActionResult> AddSamples([FromBody] AddSampleCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }
    }
}
