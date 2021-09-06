using MediatR;

namespace Tagster.CQRS.Queries.Handlers
{
    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
    }
}
