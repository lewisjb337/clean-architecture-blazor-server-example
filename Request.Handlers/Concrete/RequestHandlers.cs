using Microsoft.Extensions.DependencyInjection;
using Request.Handlers.Concrete.Interfaces;
using Request.Handlers.Contracts;
using Request.Handlers.Exceptions;

namespace Request.Handlers.Concrete;

internal class RequestHandlers : IRequestHandlers
{
    private readonly Dictionary<Type, Type?> _handlers;
    private readonly IServiceProvider _serviceProvider;

    public RequestHandlers(Dictionary<Type, Type?> handlers,
        IServiceProvider serviceProvider)
    {
        _handlers = handlers;
        _serviceProvider = serviceProvider;
    }

    public IHandler<TRequest, TResponse> GetHandler<TRequest, TResponse>()
        where TRequest : IRequest<TResponse>
    {
        return _handlers.TryGetValue(typeof(TRequest), out var type)
            ? _serviceProvider.GetRequiredService(type) as IHandler<TRequest, TResponse>
            : throw new HandlerNotRegisteredException();
    }

    public IHandler<TRequest> GetHandler<TRequest>() where TRequest : IRequest
    {
        return _handlers.TryGetValue(typeof(TRequest), out var type)
            ? _serviceProvider.GetRequiredService(type) as IHandler<TRequest>
            : throw new HandlerNotRegisteredException();
    }
}