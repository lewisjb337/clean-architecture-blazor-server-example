using Application.Entities.Requests;
using Application.Entities.Responses;
using Domain.Entities.Foo;
using Models.Requests;
using Persistence.Contexts;
using Request.Handlers.Contracts;

namespace Persistence.Features.Foo.Commands.Create;

public class CreateFooHandler : IHandler<CreateFooRequest, FooResponse>
{
    private readonly ApplicationDbContext _context;

    public CreateFooHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<FooResponse> HandleAsync(CreateFooRequest request, CancellationToken cancellationToken)
    {
        var foo = await _context.Foo.AddAsync(new FooEntity {
            UserId = request.UserId,
            Title = request.Title, 
            IsCompleted = request.IsCompleted
        }, cancellationToken);

        var changes = await _context.SaveChangesAsync(cancellationToken);

        if (changes <= 0)
            throw new Exception($"Failed to save changes for creation of: {request}");

        return FooResponse.FromEntity(foo.Entity);
    }
}