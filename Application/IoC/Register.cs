using Application.Features.Tasks.Commands;
using Application.Features.Tasks.Queries;
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