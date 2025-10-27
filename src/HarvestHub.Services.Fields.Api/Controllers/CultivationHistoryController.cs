using HarvestHub.Services.Fields.Application.CultivationHistories.Commands.AddFertilizationHistoryRecord;
using HarvestHub.Services.Fields.Application.CultivationHistories.Commands.AddHarvestHistoryRecord;
using HarvestHub.Services.Fields.Application.CultivationHistories.Commands.DeleteHistoryRecord;
using HarvestHub.Services.Fields.Application.CultivationHistories.Commands.UpdateHistoryRecord;
using HarvestHub.Services.Fields.Application.CultivationHistories.Dtos;
using HarvestHub.Services.Fields.Application.CultivationHistories.Queries;
using HarvestHub.Shared.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HarvestHub.Services.Fields.Api.Controllers
{
    [Route("api/fields/{fieldId:guid}/history")]
    public class CultivationHistoryController : ApiController
    {
        public CultivationHistoryController(ISender sender, IUserContextService userContextService) : base(sender, userContextService) { }

        [HttpPost("harvest")]
        public async Task<ActionResult> AddHarvestHistoryRecord([FromRoute] Guid fieldId, [FromBody] AddHarvestHistoryRecordByFieldIdRequest request, CancellationToken cancellationToken)
        {
            var (date, amount, cropType, humidity) = request;

            var ownerId = _userContextService.GetUserId;

            var historyRecordId = Guid.NewGuid();

            await _sender.Send(
                new AddHarvestHistoryRecordByFieldIdCommand(
                    fieldId, 
                    ownerId,
                    historyRecordId,
                    date,
                    amount,
                    cropType,
                    humidity), cancellationToken);

            return CreatedAtAction(nameof(GetHarvestHistoryRecords), new { FieldId = fieldId }, new { Id = historyRecordId });
        }

        [HttpGet("harvest")]
        public async Task<ActionResult<IEnumerable<HarvestHistoryRecordDto>>> GetHarvestHistoryRecords([FromRoute] Guid fieldId, CancellationToken cancellationToken)
        {
            var ownerId = _userContextService.GetUserId;

            var records = await _sender.Send(new GetHarvestHistoryRecordsByFieldIdQuery(fieldId, ownerId), cancellationToken);

            return Ok(records);
        }

        [HttpPut("harvest/{historyRecordId:guid}")]
        public async Task<ActionResult> UpdateHarvestHistoryRecord([FromRoute] Guid fieldId, [FromRoute] Guid historyRecordId, [FromBody] UpdateHarvestHistoryRecordRequest request, CancellationToken cancellationToken)
        {
            var (date, cropType, amount, humidity) = request;
            var harvestHistoryRecord = new HarvestHistoryRecordDto(historyRecordId, date, cropType, amount, humidity);

            var ownerId = _userContextService.GetUserId;

            await _sender.Send(new UpdateHistoryRecordCommand(fieldId, ownerId, harvestHistoryRecord), cancellationToken);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoryRecordDto>>> GetAllHistoryRecords([FromRoute] Guid fieldId, CancellationToken cancellationToken)
        {
            var ownerId = _userContextService.GetUserId;

            var records = await _sender.Send(new GetAllHistoryRecordsByFieldIdQuery(fieldId, ownerId), cancellationToken);

            return Ok(records);
        }

        [HttpDelete("{historyRecordId:guid}")]
        public async Task<ActionResult<IEnumerable<HistoryRecordDto>>> DeleteHistoryRecord([FromRoute] Guid fieldId, Guid historyRecordId, CancellationToken cancellationToken)
        {
            var ownerId = _userContextService.GetUserId;

            await _sender.Send(new DeleteHistoryRecordCommand(fieldId, ownerId, historyRecordId), cancellationToken);

            return NoContent();
        }

        [HttpPost("fertilization")]
        public async Task<ActionResult> AddFertilizationHistoryRecord([FromRoute] Guid fieldId, [FromBody] AddFertilizationHistoryRecordByFieldIdRequest request, CancellationToken cancellationToken)
        {
            var (date, amount, fertilizerType) = request;

            var ownerId = _userContextService.GetUserId;

            var historyRecordId = Guid.NewGuid();

            await _sender.Send(
                new AddFertilizationHistoryRecordCommand(
                    fieldId,
                    ownerId,
                    historyRecordId,
                    date,
                    amount,
                    fertilizerType
                    ), cancellationToken);

            return CreatedAtAction(nameof(GetHarvestHistoryRecords), new { FieldId = fieldId }, new { Id = historyRecordId });
        }

        [HttpPut("fertilization/{historyRecordId:guid}")]
        public async Task<ActionResult> UpdateFertilizationHistoryRecord([FromRoute] Guid fieldId, [FromRoute] Guid historyRecordId, [FromBody] UpdateFertilizationHistoryRecordRequest request, CancellationToken cancellationToken)
        {
            var (date, fertilizationType, amount) = request;
            var harvestHistoryRecord = new FertilizationHistoryRecordDto(historyRecordId, date, fertilizationType, amount);

            var ownerId = _userContextService.GetUserId;

            await _sender.Send(new UpdateHistoryRecordCommand(fieldId, ownerId, harvestHistoryRecord), cancellationToken);

            return Ok();
        }
    }
}
