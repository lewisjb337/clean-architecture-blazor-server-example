using Domain.Entities.Foo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserAdmin.Database.Mapping;

namespace Persistence.Configurations.FooConfig;

internal class FooConfig : AppEntityConfig<FooEntity>
{
    protected override void PostConfigure(EntityTypeBuilder<FooEntity> builder)
    {
        builder.ToTable("Foo");
        builder.Property(x => x.Title)
            .HasMaxLength(100);
        builder.Property(x => x.IsCompleted);
        base.PostConfigure(builder);
    }
}