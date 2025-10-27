using HarvestHub.Services.Fields.Application.Fields.Commands.InsertVertices;
using HarvestHub.Services.Fields.Application.Fields.Commands.ReplaceVertices;
using HarvestHub.Services.Fields.Application.Fields.Commands.UpdateVertices;
using HarvestHub.Services.Fields.Application.Fields.Dtos;
using HarvestHub.Shared.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HarvestHub.Services.Fields.Api.Controllers
{
    [Route("api/fields/{fieldId:guid}/vertices")]
    public class VerticesController : ApiController
    {
        public VerticesController(ISender sender, IUserContextService userContextService) : base(sender, userContextService) { }

        [HttpPost("insert")]
        public async Task<ActionResult> Insert([FromRoute] Guid fieldId, [FromBody] InsertVerticesRequest request, CancellationToken cancellationToken)
        {
            var (verticesDto, area) = request;

            var ownerId = _userContextService.GetUserId;

            await _sender.Send(new InsertVerticesCommand(fieldId, ownerId, verticesDto, area), cancellationToken);

            return Ok();
        }

        [HttpPost("replace")]
        public async Task<ActionResult> Replace([FromRoute] Guid fieldId, [FromBody] ReplaceVerticesRequest request, CancellationToken cancellationToken)
        {
            var (verticesDto, area, pointDto) = request;

            var ownerId = _userContextService.GetUserId;

            await _sender.Send(new ReplaceVerticesCommand(fieldId, ownerId, verticesDto, area, pointDto), cancellationToken);

            return Ok();
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update([FromRoute] Guid fieldId, [FromBody] UpdateVerticesRequest request, CancellationToken cancellationToken)
        {
            var (verticesDto, area, pointDto) = request;

            var ownerId = _userContextService.GetUserId;

            await _sender.Send(new UpdateVerticesCommand(fieldId, ownerId, verticesDto, area, pointDto), cancellationToken);

            return Ok();
        }
    }
}
