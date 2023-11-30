using Domain.Entities.Foo;
using Models.Requests;
using Persistence.Contexts;

namespace Persistence.Features.Foo.Commands.Create;

public class CreateFooHandler
{
    private readonly ApplicationDbContext _context;

    public CreateFooHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task HandleAsync(FooRequest request, CancellationToken cancellationToken)
    {
        await _context.Foo.AddAsync(new FooEntity { 
            UserId = request.UserId, 
            Title = request.Title, 
            IsCompleted = request.IsCompleted, 
            CreatedAt = DateTimeOffset.Now 
        }, cancellationToken);

        var changes = await _context.SaveChangesAsync(cancellationToken);

        if (changes <= 0)
            throw new Exception($"Failed to save changes for creation of: {request}");
    }
}