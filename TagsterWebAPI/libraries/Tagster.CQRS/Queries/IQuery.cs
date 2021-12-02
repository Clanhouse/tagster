using MediatR;

namespace Tagster.CQRS.Queries;

public interface IQuery<out TResult> : IRequest<TResult>
{
}
