﻿using Domain.Entities.Foo;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Models;
using System.Reflection;
using UserAdmin.Database.Mapping;

namespace Persistence.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<UserProfile>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FooEntity> Foo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typeConfigurations = Assembly.GetExecutingAssembly()
                .GetTypes().Where(x => (x.BaseType?.IsGenericType ?? false)
                                       && x.BaseType.GetGenericTypeDefinition() == typeof(AppEntityConfig<>));

            foreach (var typeConfiguration in typeConfigurations)
            {
                var config = Activator.CreateInstance(typeConfiguration) as IMapping;
                config?.ApplyConfiguration(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}