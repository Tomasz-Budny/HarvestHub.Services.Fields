using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Services.Fields.Core.Owners.Exceptions
{
    public class StartLocationNotSetException : HarvestHubException
    {
        public Guid OwnerId { get; }

        public StartLocationNotSetException(Guid ownerId) : base($"Start location for owner with id: {ownerId} has not been provided!")
        {
            OwnerId = ownerId;
        }
    }
}
