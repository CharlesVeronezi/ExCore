namespace SagiCore.Shared.Application.Abstractions
{
    public interface IModuleInitializer
    {
        void Initialize(IServiceProvider serviceProvider);
    }
}
