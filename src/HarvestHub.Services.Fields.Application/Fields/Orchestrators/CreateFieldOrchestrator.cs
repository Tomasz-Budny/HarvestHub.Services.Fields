using HarvestHub.Services.Fields.Application.Fields.Commands.CreateField;
using HarvestHub.Services.Fields.Application.Fields.Commands.DeleteField;
using HarvestHub.Services.Fields.Application.RPC;
using MediatR;

namespace HarvestHub.Services.Fields.Application.Fields.Orchestrators
{
    public interface ICreateFieldOrchestrator
    {
        Task CreateField(CreateFieldCommand createFieldCommand);
    }

    internal class CreateFieldOrchestrator : ICreateFieldOrchestrator
    {
        protected readonly ISender _sender;
        protected readonly ICultivationHistoryClient _client;

        public CreateFieldOrchestrator(ISender sender, ICultivationHistoryClient client)
        {
            _sender = sender;
            _client = client;
        }

        public async Task CreateField(CreateFieldCommand createFieldCommand)
        {
            try
            {
                await _sender.Send(createFieldCommand);
                await _client.CreateCulticationHistory(createFieldCommand.FieldId);
            }
            catch(Exception e)
            {
                await RollbackCreateField(createFieldCommand);
            }
        }

        private async Task RollbackCreateField(CreateFieldCommand createFieldCommand)
        {
            await _sender.Send(new DeleteFieldCommand(createFieldCommand.FieldId, createFieldCommand.OwnerId));
        }
    }
}
