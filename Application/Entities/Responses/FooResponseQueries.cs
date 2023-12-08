using Domain.Entities.Foo;

namespace Application.Entities.Responses;

public class FooResponseQueries {}

public record FooResponse
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }

    private FooResponse(FooEntity entity)
    {
        Id = entity.Id;
        UserId = entity.UserId;
        Title = entity.Title;
        IsCompleted = entity.IsCompleted;
    }

    public static FooResponse FromEntity(FooEntity entity) => new(entity);
}