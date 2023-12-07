using Microsoft.Extensions.Logging;
using Request.Handlers.Concrete.Interfaces;
using Request.Handlers.Contracts;

namespace Request.Handlers.Concrete;

internal class RequestHandler : IRequestHandler
{
    private readonly IRequestHandlers _handlers;
    private readonly ILogger<RequestHandler> _logger;

    public RequestHandler(IRequestHandlers handlers,
        ILogger<RequestHandler> logger)
    {
        _handlers = handlers;
        _logger = logger;
    }

    public async Task<TResponse> ExecuteAsync<TRequest, TResponse>(TRequest request, CancellationToken token)
        where TRequest : IRequest<TResponse>
    {
        try
        {
            var handler = _handlers.GetHandler<TRequest, TResponse>();
            return await handler.HandleAsync(request, token);
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, $"Failed to process request: {request}");
            throw;
        }
    }

    public async Task ExecuteAsync<TRequest>(TRequest request, CancellationToken token)
        where TRequest : IRequest
    {
        try
        {
            var handler = _handlers.GetHandler<TRequest>();
            await handler.HandleAsync(request, token);
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, $"Failed to process request: {request}");
            throw;
        }
    }
}