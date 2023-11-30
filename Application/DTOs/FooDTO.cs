namespace Application.DTOs;

public class FooDTO
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}
