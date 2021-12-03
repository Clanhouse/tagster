using System.Net;
using Tagster.Exception.Models;

namespace Tagster.Application.Exceptions;

public class InvalidAggregateIdException : AppException
{
    public override string Code { get; } = "invalid_aggregate_id";
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;

    public InvalidAggregateIdException() : base($"Invalid aggregate id.")
    {
    }
}
