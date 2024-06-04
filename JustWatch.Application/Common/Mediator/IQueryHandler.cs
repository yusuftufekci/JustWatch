using MediatR;

namespace JustWatch.Application.Common.Mediator
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
         where TQuery : IQuery<TResponse>
    {
    }
}
