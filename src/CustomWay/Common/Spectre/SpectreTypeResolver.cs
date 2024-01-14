using Spectre.Console.Cli;

namespace CustomWay.Common.Spectre;

public sealed class SpectreTypeResolver : ITypeResolver, IDisposable
{
    private readonly IServiceProvider _serviceProvider;

    public SpectreTypeResolver(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    public void Dispose()
    {
        if (_serviceProvider is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }

    public object Resolve(Type type)
    {
        if (type == null)
        {
            return null;
        }

        return _serviceProvider.GetService(type) ?? Activator.CreateInstance(type);
    }
}