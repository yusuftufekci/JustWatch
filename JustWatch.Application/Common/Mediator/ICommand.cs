using MediatR;

namespace JustWatch.Application.Common.Mediator
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
