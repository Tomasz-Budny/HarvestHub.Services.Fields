using HarvestHub.Services.Fields.Application.Fields.Dtos;
using HarvestHub.Services.Fields.Application.Fields.Mappers;
using HarvestHub.Services.Fields.Application.Fields.Queries;
using HarvestHub.Services.Fields.Core.Fields.Aggregates;
using HarvestHub.Services.Fields.Core.SharedKernel.ValueObjects;
using HarvestHub.Shared.Messaging;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Services.Fields.Infrastructure.Persistance.Queries.Handlers
{
    internal sealed class GetAllFieldsQueryHandler : IQueryHandler<GetAllFieldsQuery, IEnumerable<FieldDto>>
    {
        private readonly DbSet<Field> _fields;

        public GetAllFieldsQueryHandler(FieldsDbContext dbContext)
        {
            _fields = dbContext.Fields;
        }
        public async Task<IEnumerable<FieldDto>> Handle(GetAllFieldsQuery request, CancellationToken cancellationToken)
        {
            return await _fields
                .AsNoTracking()
                .Include(x => x.Vertices.OrderBy(vertex => vertex.Order))
                .Where(x => x.OwnerId == new OwnerId(request.OwnerId))
                .OrderBy(x => x.CreatedAt)
                .Select(x => FieldMapper.MapToDto(x))
                .ToListAsync(cancellationToken);
        }
    }
}
