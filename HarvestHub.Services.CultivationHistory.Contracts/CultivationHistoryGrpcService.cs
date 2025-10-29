using CultivationHistoryRPC;
using Grpc.Core;

namespace HarvestHub.Services.CultivationHistories.Contracts
{
    public class CultivationHistoryGrpcService : CultivationHistoryService.CultivationHistoryServiceBase
    {
        public override Task<CreateCultivationHistoryReply> CreateCultivationHistory(CreateCultivationHistoryRequest request, ServerCallContext context)
        {
            return base.CreateCultivationHistory(request, context);
        }

        public override Task<DeleteCultivationHistoryReply> DeleteCultivationHistory(DeleteCultivationHistoryRequest request, ServerCallContext context)
        {
            return base.DeleteCultivationHistory(request, context);
        }
    }
}
