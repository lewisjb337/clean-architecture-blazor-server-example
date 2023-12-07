using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Services;
using UserAdmin.Database.Models;

namespace Persistence.IoC;

public static class Register
{
    public static void RegisterPersistenceServices(this IServiceCollection services, DatabaseOptions options)
    {
        services.AddScoped<UserContext>();
    }
}