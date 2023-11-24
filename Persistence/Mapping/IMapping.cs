using Microsoft.EntityFrameworkCore;

namespace UserAdmin.Database.Mapping;

public interface IMapping
{
    void ApplyConfiguration(ModelBuilder builder);
}