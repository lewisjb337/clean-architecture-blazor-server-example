using Domain.Entities.Foo;
using Models.Requests;
using Persistence.Contexts;

namespace Persistence.Features.Foo.Commands.Create;

public class CreateFooCommandHandler
{
    private readonly ApplicationDbContext _context;

    public CreateFooCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task HandleAsync(FooRequest command, CancellationToken cancellationToken)
    {
        await _context.Foo.AddAsync(new FooEntity { 
            UserId = command.UserId, 
            Title = command.Title, 
            IsCompleted = false, 
            CreatedAt = DateTimeOffset.Now 
        }, cancellationToken);
    }
}