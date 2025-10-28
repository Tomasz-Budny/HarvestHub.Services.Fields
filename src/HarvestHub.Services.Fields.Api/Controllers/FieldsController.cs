using Microsoft.AspNetCore.Mvc;
using HarvestHub.Services.Fields.Application.Fields.Commands.CreateField;
using MediatR;
using HarvestHub.Services.Fields.Application.Fields.Queries;
using HarvestHub.Services.Fields.Application.Fields.Dtos;
using HarvestHub.Services.Fields.Application.Fields.Commands.DeleteField;
using HarvestHub.Services.Fields.Application.Fields.Commands.PatchFieldDetails;
using HarvestHub.Shared.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace HarvestHub.Services.Fields.Api.Controllers
{
    [Route("api/fields")]
    [Authorize]
    public class FieldsController : ApiController
    {
        public FieldsController(ISender sender, IUserContextService userContextService) : base(sender, userContextService) { }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateFieldRequest request, CancellationToken cancellationToken)
        {
            var (name, center, area, color, vertices) = request;
            var fieldId = Guid.NewGuid();

            var ownerId = _userContextService.GetUserId;

            await _sender.Send(new CreateFieldCommand(fieldId, ownerId, name, center, area, color, vertices), cancellationToken);

            return CreatedAtAction(nameof(Get), new { Id = fieldId }, new { Id = fieldId }); 
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FieldDto>> Get([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var field = await _sender.Send(new GetFieldQuery(id), cancellationToken);

            return Ok(field);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FieldDto>>> GetAll(CancellationToken cancellationToken)
        {
            var ownerId = _userContextService.GetUserId;

            var fields = await _sender.Send(new GetAllFieldsQuery(ownerId), cancellationToken);

            return Ok(fields);
        }

        [HttpDelete("{fieldId:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid fieldId, CancellationToken cancellationToken)
        {
            var ownerId = _userContextService.GetUserId;

            await _sender.Send(new DeleteFieldCommand(fieldId, ownerId), cancellationToken);

            return Ok(fieldId);
        }

        [HttpGet("{fieldId:guid}/details")]
        public async Task<ActionResult<FieldDetailsDto>> GetDetails([FromRoute] Guid fieldId, CancellationToken cancellationToken)
        {
            var ownerId = _userContextService.GetUserId;

            var field = await _sender.Send(new GetFieldDetailsQuery(ownerId, fieldId), cancellationToken);

            return Ok(field);
        }

        [HttpPatch("{fieldId:guid}/details")]
        public async Task<ActionResult> PatchFieldDetails([FromRoute] Guid fieldId,[FromBody] PatchFieldDetailsRequest request, CancellationToken cancellationToken)
        {
            var (name, classStatus, ownershipStatus, color) = request;

            var ownerId = _userContextService.GetUserId;

            await _sender.Send(new PatchFieldDetailsCommand(fieldId, ownerId, name, classStatus, ownershipStatus, color), cancellationToken);

            return Ok();
        }
    }
}
