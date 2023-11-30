using Application.Services.Foo;
using Microsoft.Extensions.DependencyInjection;

namespace Application.IoC;

public static class Register
{
    public static void RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IFooService, FooService>();
    }
}