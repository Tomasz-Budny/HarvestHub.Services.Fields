using AutoMapper;
using HarvestHub.Services.Fields.Application.CultivationHistories.Dtos;
using HarvestHub.Services.Fields.Core.CultivationHistories.Entities;

namespace HarvestHub.Services.Fields.Application.CultivationHistories.Mappers
{
    internal class CultivationHistoryProfile : Profile
    {
        public CultivationHistoryProfile()
        {
            CreateMap<HarvestHistoryRecord, HarvestHistoryRecordDto>()
                .ForMember(dto => dto.Amount, source => source.MapFrom(x => x.Amount))
                .ForMember(dto => dto.Humidity, source => source.MapFrom(x => x.Humidity));

            CreateMap<FertilizationHistoryRecord, FertilizationHistoryRecordDto>()
                .ForMember(dto => dto.Amount, source => source.MapFrom(x => x.Amount));

            CreateMap<HistoryRecord, HistoryRecordDto>()
                .Include<HarvestHistoryRecord, HarvestHistoryRecordDto>()
                .Include<FertilizationHistoryRecord, FertilizationHistoryRecordDto>()
                .ForMember(dto => dto.Id, source => source.MapFrom(x => x.Id))
                .ForMember(dto => dto.Type, source => source.MapFrom(x => x.GetType().Name.Replace("HistoryRecord", string.Empty).ToLower()));

            CreateMap<HarvestHistoryRecordDto, HarvestHistoryRecord>()
                .ForMember(x => x.Id, dto => dto.MapFrom(x => x.Id))
                .ForMember(x => x.Amount, dto => dto.MapFrom(x => x.Amount))
                .ForMember(x => x.Humidity, dto => dto.MapFrom(x => x.Humidity));

            CreateMap<FertilizationHistoryRecordDto, FertilizationHistoryRecord>()
                .ForMember(x => x.Id, dto => dto.MapFrom(x => x.Id))
                .ForMember(x => x.Amount, dto => dto.MapFrom(x => x.Amount));

            CreateMap<HistoryRecordDto, HistoryRecord>()
                .Include<HarvestHistoryRecordDto, HarvestHistoryRecord>()
                .Include<FertilizationHistoryRecordDto, FertilizationHistoryRecord>()
                .ForMember(x => x.Id, dto => dto.MapFrom(x => x.Id));
        }
    }
}
