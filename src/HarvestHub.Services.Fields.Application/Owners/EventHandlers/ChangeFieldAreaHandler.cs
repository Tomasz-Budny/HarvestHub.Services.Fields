using HarvestHub.Services.Fields.Shared.Events.Fields;
using HarvestHub.Shared.Events;
using HarvestHub.Services.Fields.Core.Owners.Repositories;
using HarvestHub.Services.Fields.Core.Owners.Exceptions;

namespace HarvestHub.Services.Fields.Application.Owners.EventHandlers
{
    internal class ChangeFieldAreaHandler : IEventHandler<FieldAreaChanged>
    {
        private readonly IOwnerRepository _ownerRepository;

        public ChangeFieldAreaHandler(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        public async Task HandleAsync(FieldAreaChanged @event, CancellationToken cancellationToken = default)
        {
            var owner = await _ownerRepository.GetAsync(@event.OwnerId, cancellationToken);

            if (owner is null)
            {
                throw new OwnerNotFoundException(@event.OwnerId);
            }

            owner.ChangeFieldArea(@event.OldArea, @event.NewArea);

            await _ownerRepository.UpdateAsync(owner, cancellationToken);
        }
    }
}
