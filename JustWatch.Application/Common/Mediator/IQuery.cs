using MediatR;

namespace JustWatch.Application.Common.Mediator
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
