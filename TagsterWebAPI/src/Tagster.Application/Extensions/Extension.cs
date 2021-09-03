using Microsoft.Extensions.DependencyInjection;

namespace Tagster.Application.Extensions
{
    public static class Extension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
            => services;
    }
}
