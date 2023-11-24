using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserAdmin.Database.Mapping;

namespace Persistence.Configurations.FooConfig;

internal class FooConfig : AppEntityConfig<Foo>
{
    protected override void PostConfigure(EntityTypeBuilder<Foo> builder)
    {
        builder.ToTable("Foo");
        builder.Property(x => x.Title)
            .HasMaxLength(100);
        builder.Property(x => x.IsCompleted);
        base.PostConfigure(builder);
    }
}