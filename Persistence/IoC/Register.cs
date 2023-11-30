using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Features.Foo.Commands.Create;
using Persistence.Features.Foo.Commands.Delete;
using Persistence.Features.Foo.Commands.Update;
using Persistence.Features.Foo.Queries.Get;
using Persistence.Features.Foo.Queries.GetById;
using Persistence.Services;
using UserAdmin.Database.Models;

namespace Persistence.IoC;

public static class Register
{
    public static void RegisterPersistenceServices(this IServiceCollection services, DatabaseOptions options)
    {
        services.AddScoped<CreateFooHandler>();
        services.AddScoped<UpdateFooHandler>();
        services.AddScoped<DeleteFooHandler>();
        services.AddScoped<GetFooHandler>();
        services.AddScoped<GetFooByIdHandler>();
        services.AddScoped<GetFooByUserIdHandler>();

        services.AddScoped<UserContext>();

        services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(options.UserAdmin));
    }
}