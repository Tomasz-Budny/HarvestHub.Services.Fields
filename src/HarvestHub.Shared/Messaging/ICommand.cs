using MediatR;

namespace HarvestHub.Shared.Messaging
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<TResponse> : IRequest<TResponse>
    {
    }
}
