using HarvestHub.Services.Fields.Application.Fields.Mappers;
using HarvestHub.Services.Fields.Application.Mappers;
using HarvestHub.Services.Fields.Core.Fields.Exceptions;
using HarvestHub.Services.Fields.Core.Fields.Repositories;
using HarvestHub.Services.Fields.Shared.Events.Fields;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Services.Fields.Application.Fields.Commands.UpdateVertices
{
    internal class UpdateVerticesCommandHandler : ICommandHandler<UpdateVerticesCommand>
    {
        private readonly IFieldRepository _fieldRepository;
        private readonly IMessageBroker _messageBroker;

        public UpdateVerticesCommandHandler(IFieldRepository fieldRepository, IMessageBroker messageBroker)
        {
            _fieldRepository = fieldRepository;
            _messageBroker = messageBroker;
        }
        public async Task Handle(UpdateVerticesCommand request, CancellationToken cancellationToken)
        {
            var (fieldId, ownerId, verticesDto, newArea, newCenter) = request;

            var field = await _fieldRepository.GetAsync(fieldId, ownerId, cancellationToken);

            if (field is null)
            {
                throw new FieldNotFoundException(fieldId);
            }

            var oldArea = field.Area.Value;
            var vertices = verticesDto.Select(x => VertexMapper.Map(x));
            field.UpdateVertices(vertices);
            field.Area = newArea;
            field.Center = PointMapper.Map(newCenter);

            await _fieldRepository.UpdateAsync(field, cancellationToken);
            await _messageBroker.PublishAsync(new FieldAreaChanged(fieldId, ownerId, oldArea, newArea), cancellationToken);
        }
    }
}
