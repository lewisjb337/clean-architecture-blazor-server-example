namespace Application.Entities.Responses;

public class FooResponseQueries {}

public record FooResponse
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}