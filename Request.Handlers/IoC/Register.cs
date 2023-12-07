using Microsoft.Extensions.DependencyInjection;
using Request.Handlers.Concrete.Interfaces;
using Request.Handlers.Concrete;
using Request.Handlers.Contracts;
using System.Reflection;
using Request.Handlers.Exceptions;

namespace Request.Handlers.IoC;

public static class Register
{
    public static void UseRequestHandler(this IServiceCollection services, Assembly assembly)
    {
        var types = assembly.GetTypes()
            .Where(x => IsAssignableToGenericType(x, typeof(IHandler<,>))
            || IsAssignableToGenericType(x, typeof(IHandler<>)));

        var handlers = GetHandlerTypes(types, services);
        services.AddSingleton<IRequestHandlers>(x => new RequestHandlers(handlers
                                                                   ?? throw new HandlerNotRegisteredException(), x));
        services.AddScoped<IRequestHandler, RequestHandler>();
    }

    public static Dictionary<Type, Type> GetHandlerTypes(IEnumerable<Type> handlers, IServiceCollection services)
    {
        var dictionary = new Dictionary<Type, Type>();

        foreach (var handler in handlers)
        {
            var requestType = handler.GetInterfaces()
                .First()
                .GetGenericArguments()[0];

            services.AddTransient(handler);

            dictionary[requestType] = handler;
        }

        return dictionary.Any()
            ? dictionary
            : null;
    }

    private static bool IsAssignableToGenericType(Type handlerType, Type interfaceType)
    {
        var interfaceTypes = handlerType.GetInterfaces();

        if (interfaceTypes.Any(it => it.IsGenericType
            && it.GetGenericTypeDefinition() == interfaceType))
            return true;

        if (handlerType.IsGenericType && handlerType.GetGenericTypeDefinition() == interfaceType)
            return true;

        var baseType = handlerType.BaseType;

        return baseType != null && IsAssignableToGenericType(baseType, interfaceType);
    }
}