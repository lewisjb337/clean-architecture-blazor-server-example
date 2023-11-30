using Microsoft.EntityFrameworkCore;
using Models.Responses;
using Persistence.Contexts;

namespace Persistence.Features.Foo.Queries.GetById;

public class GetFooByIdHandler
{
    private readonly ApplicationDbContext _context;

    public GetFooByIdHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IList<FooResponse>> HandleAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Foo
            .Where(x => x.Id.Equals(id))
            .Select(x => new FooResponse
            {
                Id = x.Id,
                UserId = x.UserId,
                Title = x.Title,
                IsCompleted = x.IsCompleted,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            }).ToListAsync(cancellationToken);
    }
}