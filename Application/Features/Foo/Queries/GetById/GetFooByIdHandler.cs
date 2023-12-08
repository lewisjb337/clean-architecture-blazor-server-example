using Application.Entities.Requests;
using Application.Entities.Responses;
using Domain.Entities.Foo;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Request.Handlers.Contracts;

namespace Persistence.Features.Foo.Queries.GetById;

public class GetFooByIdHandler : IHandler<GetFooRequestById, IList<FooResponse>>
{
    private readonly ApplicationDbContext _context;

    public GetFooByIdHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IList<FooResponse>> HandleAsync(GetFooRequestById request, CancellationToken cancellationToken)
    {
        return await _context.Foo
            .Where(x => x.Id.Equals(request.Id))
            .Select(x => FooResponse.FromEntity(new FooEntity
            {
                Id = x.Id,
                UserId = x.UserId,
                Title = x.Title,
                IsCompleted = x.IsCompleted,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            })).ToListAsync(cancellationToken);
    }
}