using MediatR;

namespace SagiCore.Shared.Application.Abstractions
{
    /// <summary>
    /// Marcador para Use Cases que retornam resultado
    /// </summary>
    public interface IUseCase<TResponse> : IRequest<TResponse>
    {
    }

    /// <summary>
    /// Marcador para Use Cases sem retorno
    /// </summary>
    public interface IUseCase : IRequest
    {
    }
}
