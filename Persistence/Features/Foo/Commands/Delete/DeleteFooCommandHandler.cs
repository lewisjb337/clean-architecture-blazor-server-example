using Microsoft.EntityFrameworkCore;
using Models.Requests;
using Persistence.Contexts;

namespace Persistence.Features.Foo.Commands.Delete;

public class DeleteFooCommandHandler
{
    private readonly ApplicationDbContext _context;

    public DeleteFooCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(FooRequest request, CancellationToken cancellationToken)
    {
        await _context.Foo
            .Where(x => x.Id.Equals(request.Id))
            .ExecuteDeleteAsync(cancellationToken);
    }
}