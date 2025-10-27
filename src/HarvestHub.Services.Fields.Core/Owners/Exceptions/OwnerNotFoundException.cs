using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Services.Fields.Core.Owners.Exceptions
{
    public class OwnerNotFoundException : HarvestHubException
    {
        public Guid OwnerId { get; }
        public OwnerNotFoundException(Guid ownerId) : base($"Owner with provided id: {ownerId} was not found!")
        {
            OwnerId = ownerId;
        }
    }
}
