using System.Reflection;
using Fask.Shared.Abstraction.Commands;
using Fask.Shared.Abstraction.Queries;
using Fask.Shared.Commands;
using Fask.Shared.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Fask.Shared;

public static class Extensions
{
    public static IServiceCollection AddCommands(this IServiceCollection services)
    {
        services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
        services.Scan(scan => scan
            .FromAssemblies(Assembly.GetCallingAssembly())
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        return services;
    }

    public static IServiceCollection AddQueries(this IServiceCollection services)
    {
        services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
        services.Scan(scan => scan
            .FromAssemblies(Assembly.GetCallingAssembly())
            .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        return services;
    }
}