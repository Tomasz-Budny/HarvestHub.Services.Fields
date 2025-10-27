using AutoMapper;
using HarvestHub.Services.Fields.Application.CultivationHistories.Dtos;
using HarvestHub.Services.Fields.Application.CultivationHistories.Mappers;
using HarvestHub.Services.Fields.Application.CultivationHistories.Queries;
using HarvestHub.Services.Fields.Application.CultivationHistories.Services;
using HarvestHub.Services.Fields.Core.CultivationHistories.Entities;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Services.Fields.Infrastructure.Persistance.Queries.CultivationHistories.Handlers
{
    internal class GetHarvestHistoryRecordsByFieldIdQueryHandler : IQueryHandler<GetHarvestHistoryRecordsByFieldIdQuery, IEnumerable<HarvestHistoryRecordDto>>
    {
        private readonly ICultivationHistoryService _cultivationHistoryService;
        private readonly IMapper _mapper;

        public GetHarvestHistoryRecordsByFieldIdQueryHandler(ICultivationHistoryService cultivationHistoryService, IMapper mapper)
        {
            _cultivationHistoryService = cultivationHistoryService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HarvestHistoryRecordDto>> Handle(GetHarvestHistoryRecordsByFieldIdQuery request, CancellationToken cancellationToken)
        {
            var (fieldId, ownerId) = request;

            var cultivationhistory = await _cultivationHistoryService.GetByFieldId(fieldId, ownerId, cancellationToken);

            var harvestHistoryRecords = cultivationhistory.GetAllByType<HarvestHistoryRecord>();

            return _mapper
                .Map<IEnumerable<HarvestHistoryRecordDto>>(harvestHistoryRecords);
            //return harvestHistoryRecords.Select(x => CultivationHistoryMapper.MapToHarvestHistoryRecordDto(x));
        }
    }
}
