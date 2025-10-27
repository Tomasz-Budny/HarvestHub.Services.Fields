using HarvestHub.Services.Fields.Application.CultivationHistories.Services;
using HarvestHub.Services.Fields.Core.CultivationHistories.Entities;
using HarvestHub.Services.Fields.Core.CultivationHistories.Repositories;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Services.Fields.Application.CultivationHistories.Commands.AddFertilizationHistoryRecord
{
    internal class AddFertilizationHistoryRecordCommandHandler : ICommandHandler<AddFertilizationHistoryRecordCommand>
    {
        private readonly ICultivationHistoryService _historyService;
        private readonly ICultivationHistoryRepository _historyRepository;

        public AddFertilizationHistoryRecordCommandHandler(ICultivationHistoryService historyService, ICultivationHistoryRepository cultivationHistoryRepository)
        {
            _historyService = historyService;
            _historyRepository = cultivationHistoryRepository;
        }
        public async Task Handle(AddFertilizationHistoryRecordCommand request, CancellationToken cancellationToken)
        {
            var (fieldId, ownerId, historyRecordId, date, amount, fertilizerType) = request;

            var history = await _historyService.GetByFieldId(fieldId, ownerId, cancellationToken);

            var fertilizationHistoryRecord = new FertilizationHistoryRecord(
                historyRecordId,
                date,
                fertilizerType,
                amount
            );

            history.Add(fertilizationHistoryRecord);

            await _historyRepository.UpdateAsync(history, cancellationToken);
        }
    }
}
