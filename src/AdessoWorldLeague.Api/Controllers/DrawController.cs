using AdessoWorldLeague.Application.Commands.Draws;
using AdessoWorldLeague.Application.Queries.Groups;
using AdessoWorldLeague.Application.Queries.Groups.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdessoWorldLeague.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DrawController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Kura çekme işlemi yapar
        /// </summary>
        /// <param name="command">CreateDrawCommand nesnesi</param>
        /// <returns>Kuranın Id'si</returns>
        [HttpPost]
        public async Task<IActionResult> CreateDraw([FromBody] CreateDrawCommand command)
        {
            var drawId = await _mediator.Send(command);
            return Ok(new { DrawId = drawId });
        }

        /// <summary>
        /// Grupları getirir
        /// </summary>
        /// <param name="drawId">Kura Id'si</param>
        /// <returns>Grupların listesi</returns>
        [HttpGet("{drawId}/groups")]
        public async Task<ActionResult<List<GroupDto>>> GetGroups(Guid drawId)
        {
            var query = new GetGroupsQuery { DrawId = drawId };
            var groups = await _mediator.Send(query);
            return Ok(groups);
        }
    }
}

