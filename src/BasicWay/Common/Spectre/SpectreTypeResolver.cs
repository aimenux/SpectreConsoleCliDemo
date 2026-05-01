using Spectre.Console.Cli;

namespace BasicWay.Common.Spectre;

public sealed class SpectreTypeResolver : ITypeResolver
{
    private readonly IServiceProvider _serviceProvider;

    public SpectreTypeResolver(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    public object? Resolve(Type? type) => type == null ? null : _serviceProvider.GetService(type);
}