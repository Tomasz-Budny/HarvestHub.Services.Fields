using HarvestHub.Services.Fields.Application.Fields.Dtos;
using HarvestHub.Services.Fields.Application.Fields.Mappers;
using HarvestHub.Services.Fields.Application.Fields.Queries;
using HarvestHub.Services.Fields.Core.Fields.Aggregates;
using HarvestHub.Services.Fields.Core.Fields.Exceptions;
using HarvestHub.Services.Fields.Core.Fields.ValueObjects;
using HarvestHub.Services.Fields.Core.SharedKernel.ValueObjects;
using HarvestHub.Shared.Messaging;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Services.Fields.Infrastructure.Persistance.Queries.Handlers
{
    internal class GetFieldDetailsQueryHandler : IQueryHandler<GetFieldDetailsQuery, FieldDetailsDto>
    {
        private readonly DbSet<Field> _fields;

        public GetFieldDetailsQueryHandler(FieldsDbContext dbContext)
        {
            _fields = dbContext.Fields;
        }
        public async Task<FieldDetailsDto> Handle(GetFieldDetailsQuery request, CancellationToken cancellationToken)
        {
            var (ownerId, fieldId) = request;

            var field = await _fields
                .SingleOrDefaultAsync(x => x.Id == new FieldId(fieldId) && 
                x.OwnerId == new OwnerId(ownerId), cancellationToken);

            if (field == null)
            {
                throw new FieldNotFoundException(fieldId);
            }

            return FieldDetailsMapper.MapToDto(field);
        }
    }
} 
