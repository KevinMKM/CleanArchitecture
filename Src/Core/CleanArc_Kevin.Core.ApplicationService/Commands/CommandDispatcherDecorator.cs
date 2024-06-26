﻿using CleanArc_Kevin.Core.Contracts.ApplicationServices.Commands;

namespace CleanArc_Kevin.Core.ApplicationService.Commands;

public abstract class CommandDispatcherDecorator : ICommandDispatcher
{
    protected ICommandDispatcher CommandDispatcher;

    protected CommandDispatcherDecorator(ICommandDispatcher commandDispatcher)
    {
        CommandDispatcher = commandDispatcher;
    }

    public abstract Task<CommandResult> Send<TCommand>(TCommand command) where TCommand : class, ICommand;

    public abstract Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command) where TCommand : class, ICommand<TData>;
}