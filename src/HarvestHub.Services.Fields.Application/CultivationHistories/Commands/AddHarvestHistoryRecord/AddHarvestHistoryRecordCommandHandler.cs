using HarvestHub.Services.Fields.Application.CultivationHistories.Services;
using HarvestHub.Services.Fields.Core.CultivationHistories.Entities;
using HarvestHub.Services.Fields.Core.CultivationHistories.Repositories;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Services.Fields.Application.CultivationHistories.Commands.AddHarvestHistoryRecord
{
    internal class AddHarvestHistoryRecordCommandHandler : ICommandHandler<AddHarvestHistoryRecordByFieldIdCommand>
    {
        private readonly ICultivationHistoryService _historyService;
        private readonly ICultivationHistoryRepository _historyRepository;

        public AddHarvestHistoryRecordCommandHandler(ICultivationHistoryService historyService, ICultivationHistoryRepository cultivationHistoryRepository)
        {
            _historyService = historyService;
            _historyRepository = cultivationHistoryRepository;
        }

        public async Task Handle(AddHarvestHistoryRecordByFieldIdCommand request, CancellationToken cancellationToken)
        {
            var (fieldId, ownerId, historyRecordId, date, amount, cropType, humidity) = request;

            var history = await _historyService.GetByFieldId(fieldId, ownerId, cancellationToken);

            var harvestHistoryRecord = new HarvestHistoryRecord(
                historyRecordId,
                date,
                amount,
                cropType,
                humidity);

            history.Add(harvestHistoryRecord);

            await _historyRepository.UpdateAsync(history, cancellationToken);
        }
    }
}
