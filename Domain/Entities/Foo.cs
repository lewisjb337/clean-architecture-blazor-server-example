using UserAdmin.Models.Entities;

namespace Domain.Entities;

public class Foo : BaseEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}