using UserAdmin.Models.Entities;

namespace Models.Responses;

public class FooResponse : BaseEntity
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}