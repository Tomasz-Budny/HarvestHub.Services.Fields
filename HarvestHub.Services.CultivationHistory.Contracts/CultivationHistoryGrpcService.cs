using CultivationHistory;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace HarvestHub.Services.CultivationHistory.Contracts
{
    public class CultivationHistoryGrpcService : CultivationHistoryService.CultivationHistoryServiceBase
    {
        public override Task<Empty> CreateCultivationHistory(CreateCultivationHistoryRequest request, ServerCallContext context)
        {
            return base.CreateCultivationHistory(request, context);
        }

        public override Task<Empty> DeleteCultivationHistory(DeleteCultivationHistoryRequest request, ServerCallContext context)
        {
            return base.DeleteCultivationHistory(request, context);
        }
    }
}
