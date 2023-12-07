using Application.Entities.Responses;
using Request.Handlers.Contracts;

namespace Application.Entities.Requests;

public class FooRequestCommands {}

public record GetFooRequest : IRequest<IList<FooResponse>>
{
}

public record GetFooRequestById : IRequest<IList<FooResponse>>
{
    public int Id { get; set; }
}

public record CreateFooRequest : IRequest<FooResponse>
{
    public string UserId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}

public record UpdateFooRequest : IRequest
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}

public record DeleteFooRequest : IRequest
{
    public int Id { get; set; }
}