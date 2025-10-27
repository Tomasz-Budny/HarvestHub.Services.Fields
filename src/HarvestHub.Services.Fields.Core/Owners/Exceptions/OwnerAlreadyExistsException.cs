using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Services.Fields.Core.Owners.Exceptions
{
    public class OwnerAlreadyExistsException : HarvestHubException
    {
        public Guid OwnerId { get; }
        public OwnerAlreadyExistsException(Guid ownerId) : base($"Owner with provided id: {ownerId} already exists!")
        {
            OwnerId = ownerId;
        }
    }
}
