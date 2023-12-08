using Application.Entities.Responses;
using Request.Handlers.Contracts;

namespace Application.Entities.Requests;

public class FooRequestCommands {}

public record GetFooRequest() : IRequest<IList<FooResponse>>;

public record GetFooRequestById(int Id) : IRequest<IList<FooResponse>>;

public record CreateFooRequest(string UserId, string Title, bool IsCompleted) : IRequest<FooResponse>;

public record UpdateFooRequest(int Id, string Title, bool IsCompleted) : IRequest;

public record DeleteFooRequest(int Id) : IRequest;