using Spectre.Console.Cli;

namespace Example02.Core.Spectre;

public sealed class SpectreTypeResolver : ITypeResolver
{
    private readonly IServiceProvider _serviceProvider;

    public SpectreTypeResolver(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    public object? Resolve(Type? type) => type == null ? null : _serviceProvider.GetService(type);
}