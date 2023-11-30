using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using UserAdmin.Database.Models;

namespace Persistence.IoC;

public static class Register
{
    public static void RegisterPersistenceServices(this IServiceCollection services, DatabaseOptions options)
    {
        services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(options.UserAdmin));
    }
}