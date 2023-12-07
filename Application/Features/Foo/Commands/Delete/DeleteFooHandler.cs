using Application.Entities.Requests;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Request.Handlers.Contracts;
using System.Threading;

namespace Persistence.Features.Foo.Commands.Delete;

public class DeleteFooHandler : IHandler<DeleteFooRequest>
{
    private readonly ApplicationDbContext _context;

    public DeleteFooHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task HandleAsync(DeleteFooRequest request, CancellationToken cancellationToken)
    {
        await _context.Foo
            .Where(x => x.Id.Equals(request.Id))
            .ExecuteDeleteAsync(cancellationToken);

        var changes = await _context.SaveChangesAsync(cancellationToken);

        if (changes <= 0)
            throw new Exception($"Failed to save changes for deletion of: {request}");
    }
}