using AutoMapper;
using HarvestHub.Services.Fields.Application.CultivationHistories.Services;
using HarvestHub.Services.Fields.Core.CultivationHistories.Entities;
using HarvestHub.Services.Fields.Core.CultivationHistories.Repositories;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Services.Fields.Application.CultivationHistories.Commands.UpdateHistoryRecord
{
    internal class UpdateHistoryRecordCommandHandler : ICommandHandler<UpdateHistoryRecordCommand>
    {
        private readonly ICultivationHistoryService _historyService;
        private readonly ICultivationHistoryRepository _historyRepository;
        private readonly IMapper _mapper;

        public UpdateHistoryRecordCommandHandler(ICultivationHistoryService historyService, ICultivationHistoryRepository cultivationHistoryRepository, IMapper mapper)
        {
            _historyService = historyService;
            _historyRepository = cultivationHistoryRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateHistoryRecordCommand request, CancellationToken cancellationToken)
        {
            var (fieldId, ownerId, updatedHistoryRecordDto) = request;

            var history = await _historyService.GetByFieldId(fieldId, ownerId, cancellationToken);

            var updatedHistoryRecord = _mapper.Map<HistoryRecord>(updatedHistoryRecordDto);

            history.Update(updatedHistoryRecord);

            await _historyRepository.UpdateAsync(history, cancellationToken);
        }
    }
}
