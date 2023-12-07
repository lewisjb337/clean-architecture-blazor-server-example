using Microsoft.Extensions.DependencyInjection;
using Request.Handlers.IoC;
using System.Reflection;

namespace Application.IoC;

public static class Register
{
    public static void RegisterApplicationServices(this IServiceCollection services)
    {
        services.UseRequestHandler(Assembly.GetExecutingAssembly());
    }
}