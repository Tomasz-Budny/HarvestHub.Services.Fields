using MediatR;

namespace HarvestHub.Shared.Messaging
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {
    }
}
