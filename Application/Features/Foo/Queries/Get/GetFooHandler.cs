using Application.Entities.Requests;
using Application.Entities.Responses;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Request.Handlers.Contracts;

namespace Persistence.Features.Foo.Queries.Get;

public class GetFooHandler : IHandler<GetFooRequest, IList<FooResponse>>
{
    private readonly ApplicationDbContext _context;

    public GetFooHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IList<FooResponse>> HandleAsync(GetFooRequest request, CancellationToken cancellationToken)
    {
        return await _context.Foo.Select(x => new FooResponse
        {
            Id = x.Id,
            UserId = x.UserId,
            Title = x.Title,
            IsCompleted = x.IsCompleted
        }).ToListAsync(cancellationToken);
    }
}
