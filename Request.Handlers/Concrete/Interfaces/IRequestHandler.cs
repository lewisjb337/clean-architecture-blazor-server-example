using Request.Handlers.Contracts;

namespace Request.Handlers.Concrete.Interfaces;

public interface IRequestHandler
{
    Task<TResponse> ExecuteAsync<TRequest, TResponse>(TRequest request, CancellationToken token)
        where TRequest : IRequest<TResponse>;

    Task ExecuteAsync<TRequest>(TRequest request, CancellationToken token)
        where TRequest : IRequest;
}