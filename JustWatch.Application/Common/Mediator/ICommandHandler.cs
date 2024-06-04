using MediatR;

namespace JustWatch.Application.Common.Mediator
{
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
         where TCommand : ICommand<TResponse>
    {
    }
}
