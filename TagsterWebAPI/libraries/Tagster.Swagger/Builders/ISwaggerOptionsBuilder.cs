using Tagster.Swagger.Options;

namespace Tagster.Swagger.Builders
{
    public interface ISwaggerOptionsBuilder
    {
        ISwaggerOptionsBuilder Enable(bool enabled);
        ISwaggerOptionsBuilder WithName(string name);
        ISwaggerOptionsBuilder WithTitle(string title);
        ISwaggerOptionsBuilder WithVersion(string version);
        ISwaggerOptionsBuilder WithRoutePrefix(string routePrefix);
        ISwaggerOptionsBuilder IncludeSecurity(bool includeSecurity);
        SwaggerOptions Build();
    }
}