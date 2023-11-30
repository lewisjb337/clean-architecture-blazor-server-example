﻿using Microsoft.EntityFrameworkCore;
using Models.Requests;
using Persistence.Contexts;

namespace Persistence.Features.Foo.Commands.Delete;

public class DeleteFooHandler
{
    private readonly ApplicationDbContext _context;

    public DeleteFooHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(FooRequest request, CancellationToken cancellationToken)
    {
        await _context.Foo
            .Where(x => x.Id.Equals(request.Id))
            .ExecuteDeleteAsync(cancellationToken);

        var changes = await _context.SaveChangesAsync(cancellationToken);

        if (changes <= 0)
            throw new Exception($"Failed to save changes for deletion of: {request}");
    }
}