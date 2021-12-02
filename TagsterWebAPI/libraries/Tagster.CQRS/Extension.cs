using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Tagster.CQRS.Behaviors;

namespace Tagster.CQRS;

public static class Extension
{
    public static IServiceCollection AddCQRS(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddMediatR(config => { }, assemblies);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestLogingBehavior<,>));

        return services;
    }

}
