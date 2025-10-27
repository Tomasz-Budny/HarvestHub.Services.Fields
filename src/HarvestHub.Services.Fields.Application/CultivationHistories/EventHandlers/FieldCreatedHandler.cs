using HarvestHub.Services.Fields.Application.CultivationHistories.Services;
using HarvestHub.Services.Fields.Core.CultivationHistories.Aggregates;
using HarvestHub.Services.Fields.Core.CultivationHistories.Exceptions;
using HarvestHub.Services.Fields.Core.CultivationHistories.Repositories;
using HarvestHub.Services.Fields.Shared.Events.Fields;
using HarvestHub.Shared.Events;

namespace HarvestHub.Services.Fields.Application.CultivationHistories.EventHandlers
{
    internal class FieldCreatedHandler : IEventHandler<FieldCreated>
    {
        public readonly ICultivationHistoryService _cultivationHistoryService;
        public readonly ICultivationHistoryRepository _cultivationHistoryRepository;

        public FieldCreatedHandler(ICultivationHistoryService cultivationHistoryService, ICultivationHistoryRepository cultivationHistoryRepository)
        {
            _cultivationHistoryService = cultivationHistoryService;
            _cultivationHistoryRepository = cultivationHistoryRepository;
        }

        public async Task HandleAsync(FieldCreated @event, CancellationToken cancellationToken = default)
        {
            var (fieldId, _, _, _) = @event;

            if (await _cultivationHistoryService.ExistsByFieldId(fieldId, cancellationToken))
            {
                throw new CultivationHistoryWithFieldIdAlreadyExistsException(fieldId);
            }

            var cultivationHistoryId = Guid.NewGuid();
            var cultivationHistory = new CultivationHistory(cultivationHistoryId, fieldId);

            await _cultivationHistoryRepository.AddAsync(cultivationHistory, cancellationToken);
        }
    }
}
