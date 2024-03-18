using Fask.Shared.Abstraction.Commands;

namespace Fask.Shared.Commands;

public sealed class CommandDispatcher(IServiceProvider _serviceProvider) : ICommandDispatcher
{
    public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand
    {
        var handler = _serviceProvider.GetService(typeof(ICommandHandler<TCommand>)) as ICommandHandler<TCommand>;
        await handler?.HandleAsync(command)!;
    }
}