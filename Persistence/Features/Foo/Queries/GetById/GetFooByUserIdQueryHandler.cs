using Microsoft.EntityFrameworkCore;
using Models.Responses;
using Persistence.Contexts;

namespace Persistence.Features.Foo.Queries.GetById;

public class GetFooByUserIdQueryHandler
{
    private readonly ApplicationDbContext _context;

    public GetFooByUserIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IList<FooResponse>> HandleAsync(string id, CancellationToken cancellationToken)
    {
        return await _context.Foo
            .Where(x => x.UserId.Equals(id))
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