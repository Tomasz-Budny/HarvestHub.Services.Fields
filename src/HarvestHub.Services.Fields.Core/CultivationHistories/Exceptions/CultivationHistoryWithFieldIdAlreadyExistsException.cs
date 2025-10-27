using HarvestHub.Shared.Exceptions;

namespace HarvestHub.Services.Fields.Core.CultivationHistories.Exceptions
{
    public class CultivationHistoryWithFieldIdAlreadyExistsException : HarvestHubException
    {
        public Guid Id { get; }
        public CultivationHistoryWithFieldIdAlreadyExistsException(Guid id) : base($"Cultivation history with provided field id: {id} already exists!")
        {
            Id = id;
        }
    }
}
