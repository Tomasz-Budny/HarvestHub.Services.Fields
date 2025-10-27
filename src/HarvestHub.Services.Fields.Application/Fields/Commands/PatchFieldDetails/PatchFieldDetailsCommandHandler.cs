using HarvestHub.Services.Fields.Core.CultivationHistories.Repositories;
using HarvestHub.Services.Fields.Core.Fields.Exceptions;
using HarvestHub.Services.Fields.Core.Fields.Repositories;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Services.Fields.Application.Fields.Commands.PatchFieldDetails
{
    internal class PatchFieldDetailsCommandHandler : ICommandHandler<PatchFieldDetailsCommand>
    {
        private readonly IFieldRepository _fieldRepository;
        private readonly ICultivationHistoryRepository _cultivationHistoryRepository;

        public PatchFieldDetailsCommandHandler(IFieldRepository fieldRepository, ICultivationHistoryRepository cultivationHistoryRepository)
        {
            _fieldRepository = fieldRepository;
            _cultivationHistoryRepository = cultivationHistoryRepository;
        }
        public async Task Handle(PatchFieldDetailsCommand request, CancellationToken cancellationToken)
        {
            var (fieldId, ownerId, name, classStatus, ownershipStatus, color) = request;

            var field = await _fieldRepository.GetAsync(fieldId, ownerId, cancellationToken);

            if (field is null)
            {
                throw new FieldNotFoundException(fieldId);
            }

            if(name is not null)
            {
                field.Name = name;
            }

            if (classStatus is not null)
            {
                field.Class = classStatus.Value;
            }

            if(ownershipStatus is not null)
            {
                field.OwnershipStatus = ownershipStatus.Value;
            }

            if(color is not null)
            {
                field.Color = color;
            }

            await _fieldRepository.UpdateAsync(field, cancellationToken);
        }
    }
}
