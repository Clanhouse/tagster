﻿using MediatR;

namespace Tagster.CQRS.Commands.Handlers
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Unit> where TCommand : ICommand
    {
    }

    public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {
    }
}
