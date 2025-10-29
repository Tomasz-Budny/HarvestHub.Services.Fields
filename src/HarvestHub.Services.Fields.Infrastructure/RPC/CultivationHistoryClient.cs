using CultivationHistoryRPC;
using Grpc.Net.Client;
using HarvestHub.Services.Fields.Application.RPC;
using HarvestHub.Services.Fields.Infrastructure.RPC.Options;

namespace HarvestHub.Services.Fields.Infrastructure.RPC
{
    internal class CultivationHistoryClient : ICultivationHistoryClient
    {
        protected readonly ClientOptions _clientOptions;
        public CultivationHistoryClient(ClientOptions clientOptions)
        {
            _clientOptions = clientOptions;
        }

        public async Task CreateCulticationHistory(Guid fieldId)
        {
            using var channel = GrpcChannel.ForAddress(_clientOptions.CultivationHistoryAdresUrl);
            var client = new CultivationHistoryService.CultivationHistoryServiceClient(channel);

            await client.CreateCultivationHistoryAsync(new CreateCultivationHistoryRequest { FieldId = fieldId.ToString() });
        }
    }
}
