using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace CustomWay.Common.Spectre;

public sealed class SpectreTypeRegistrar(IServiceCollection builder) : ITypeRegistrar
{
    private readonly IServiceCollection _services = builder ?? throw new ArgumentNullException(nameof(builder));

    public ITypeResolver Build()
    {
        return new SpectreTypeResolver(_services.BuildServiceProvider());
    }

    public void Register(Type service, Type implementation)
    {
        _services.AddSingleton(service, implementation);
    }

    public void RegisterInstance(Type service, object implementation)
    {
        _services.AddSingleton(service, implementation);
    }

    public void RegisterLazy(Type service, Func<object> func)
    {
        ArgumentNullException.ThrowIfNull(func);

        _services.AddSingleton(service, _ => func());
    }
}