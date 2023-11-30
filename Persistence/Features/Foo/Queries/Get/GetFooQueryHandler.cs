using Domain.Entities.Foo;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Models.Responses;

namespace Persistence.Features.Foo.Queries.Get;

public class GetFooQueryHandler
{
    private readonly ApplicationDbContext _context;

    public GetFooQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IList<FooResponse>> HandleAsync(CancellationToken cancellationToken)
    {
        return await _context.Foo.Select(x => new FooResponse
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
