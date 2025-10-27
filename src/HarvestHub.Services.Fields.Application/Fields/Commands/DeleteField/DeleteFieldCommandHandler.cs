using HarvestHub.Services.Fields.Core.Fields.Exceptions;
using HarvestHub.Services.Fields.Core.Fields.Repositories;
using HarvestHub.Services.Fields.Shared.Events.Fields;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Services.Fields.Application.Fields.Commands.DeleteField
{
    internal class DeleteFieldCommandHandler : ICommandHandler<DeleteFieldCommand>
    {
        private readonly IFieldRepository _fieldRepository;
        private readonly IMessageBroker _messageBroker;

        public DeleteFieldCommandHandler(IFieldRepository fieldRepository, IMessageBroker messageBroker)
        {
            _fieldRepository = fieldRepository;
            _messageBroker = messageBroker;
        }
        public async Task Handle(DeleteFieldCommand request, CancellationToken cancellationToken)
        {
            var (fieldId, ownerId) = request;

            var field = await _fieldRepository.GetAsync(fieldId, ownerId, cancellationToken);

            if (field is null)
            {
                throw new FieldNotFoundException(fieldId);
            }

            await _fieldRepository.DeleteAsync(field, cancellationToken);
            await _messageBroker.PublishAsync(new FieldDeleted(fieldId, ownerId, field.Name, field.Area), cancellationToken);
        }
    }
}
