using Application.Features.Foo.Commands.Create;
using Application.Features.Foo.Commands.Delete;
using Application.Features.Foo.Commands.Update;
using Application.Features.Foo.Queries.Get;
using Application.Features.Foo.Queries.GetById;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.IoC;

public static class Register
{
    public static void RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<CreateFooCommandHandler>();
        services.AddScoped<UpdateFooCommandHandler>();
        services.AddScoped<DeleteFooCommandHandler>();
        services.AddScoped<GetFooQueryHandler>();
        services.AddScoped<GetFooByIdQueryHandler>();

        services.AddScoped<IFooService, FooService>();
    }
}