using HarvestHub.Services.Fields.Core.Owners.Aggregates;
using HarvestHub.Services.Fields.Core.Owners.Exceptions;
using HarvestHub.Services.Users.Shared.Events;
using HarvestHub.Shared.Events;
using HarvestHub.Services.Fields.Core.Owners.Repositories;

namespace HarvestHub.Services.Fields.Application.Owners.EventHandlers.Externals.Users
{
    internal class UserCreatedHandler : IEventHandler<UserCreated>
    {
        private readonly IOwnerRepository _ownerRepository;

        public UserCreatedHandler(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        public async Task HandleAsync(UserCreated @event, CancellationToken cancellationToken = default)
        {
            var (id, firstName, lastName, _, _) = @event;

            if(await _ownerRepository.GetAsync(@event.Id, cancellationToken) is not null)
            {
                throw new OwnerAlreadyExistsException(@event.Id);
            }

            var owner = new Owner(id, firstName, lastName, null, null, 0, 0);

            await _ownerRepository.AddAsync(owner, cancellationToken);
        }
    }
}
