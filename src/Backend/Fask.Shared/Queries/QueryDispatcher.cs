using Fask.Shared.Abstraction.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Fask.Shared.Queries;

public sealed class QueryDispatcher(IServiceScopeFactory _serviceFactory) : IQueryDispatcher
{
    public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
    {
        await using var scope = _serviceFactory.CreateAsyncScope();
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
        var handler = scope.ServiceProvider.GetRequiredService(handlerType);

        return await (Task<TResult>) handlerType.GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync))?.Invoke(handler, [query])!;
    }
}