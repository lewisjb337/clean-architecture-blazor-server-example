namespace Application.Entities.Responses;

public class FooResponseQueries {}

public record FooResponse(int Id, string UserId, string Title, bool IsCompleted);