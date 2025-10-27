using HarvestHub.Services.Fields.Application.Fields.Dtos;
using HarvestHub.Services.Fields.Application.Fields.Queries;
using HarvestHub.Services.Fields.Core.Fields.Aggregates;
using HarvestHub.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using HarvestHub.Services.Fields.Core.Fields.Exceptions;
using HarvestHub.Services.Fields.Application.Fields.Mappers;
using HarvestHub.Services.Fields.Core.Fields.ValueObjects;
using HarvestHub.Services.Fields.Core.SharedKernel.ValueObjects;

namespace HarvestHub.Services.Fields.Infrastructure.Persistance.Queries.Handlers
{
    internal sealed class GetFieldQueryHandler : IQueryHandler<GetFieldQuery, FieldDto>
    {
        private readonly DbSet<Field> _fields;

        public GetFieldQueryHandler(FieldsDbContext dbContext)
        {
            _fields = dbContext.Fields;
        }
        public async Task<FieldDto> Handle(GetFieldQuery request, CancellationToken cancellationToken)
        {
            var field = await _fields
                .AsNoTracking()
                .Where(f => f.Id == new FieldId(request.FieldId))
                .Include(x => x.Vertices.OrderBy(vertex => vertex.Order))
                .SingleOrDefaultAsync(cancellationToken);

            if (field == null)
            {
                throw new FieldNotFoundException(request.FieldId);
            }

            return FieldMapper.MapToDto(field);
        }
    }
}
