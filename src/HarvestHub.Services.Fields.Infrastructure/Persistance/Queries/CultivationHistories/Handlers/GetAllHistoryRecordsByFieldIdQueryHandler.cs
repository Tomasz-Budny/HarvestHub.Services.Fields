using AutoMapper;
using HarvestHub.Services.Fields.Application.CultivationHistories.Dtos;
using HarvestHub.Services.Fields.Application.CultivationHistories.Queries;
using HarvestHub.Services.Fields.Application.CultivationHistories.Services;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Services.Fields.Infrastructure.Persistance.Queries.CultivationHistories.Handlers
{
    internal class GetAllHistoryRecordsByFieldIdQueryHandler : IQueryHandler<GetAllHistoryRecordsByFieldIdQuery, IEnumerable<HistoryRecordDto>>
    {
        private readonly ICultivationHistoryService _cultivationHistoryService;
        private readonly IMapper _mapper;

        public GetAllHistoryRecordsByFieldIdQueryHandler(ICultivationHistoryService cultivationHistoryService, IMapper mapper)
        {
            _cultivationHistoryService = cultivationHistoryService;
            _mapper = mapper;
        }
        public async Task<IEnumerable<HistoryRecordDto>> Handle(GetAllHistoryRecordsByFieldIdQuery request, CancellationToken cancellationToken)
        {
            var (fieldId, ownerId) = request;

            var cultivationhistory = await _cultivationHistoryService.GetByFieldId(fieldId, ownerId, cancellationToken);

            var hisoryRecordsDtos = _mapper.Map<IEnumerable<HistoryRecordDto>>(cultivationhistory.History);

            return hisoryRecordsDtos;
        }
    }
}
