using MediatR;

namespace SagiCore.Shared.Application.Abstractions
{
    public interface IUseCaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IUseCase<TResponse>
    {
    }

    public interface IUseCaseHandler<TRequest> : IRequestHandler<TRequest>
        where TRequest : IUseCase
    {
    }
}
