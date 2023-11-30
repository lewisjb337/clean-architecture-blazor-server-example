using Application.DTOs;
using Models.Requests;
using Persistence.Features.Foo.Commands.Create;
using Persistence.Features.Foo.Commands.Delete;
using Persistence.Features.Foo.Commands.Update;
using Persistence.Features.Foo.Queries.Get;
using Persistence.Features.Foo.Queries.GetById;

namespace Application.Services.Foo;

public class FooService : IFooService
{
    private readonly CreateFooCommandHandler _createFooCommandHandler;
    private readonly UpdateFooCommandHandler _updateFooCommandHandler;
    private readonly DeleteFooCommandHandler _deleteFooCommandHandler;
    private readonly GetFooQueryHandler _getFooQueryHandler;
    private readonly GetFooByIdQueryHandler _getFooByIdQueryHandler;
    private readonly GetFooByUserIdQueryHandler _getFooByUserIdQueryHandler;

    public FooService(
        CreateFooCommandHandler createFooCommandHandler,
        UpdateFooCommandHandler updateFooCommandHandler,
        DeleteFooCommandHandler deleteFooCommandHandler,
        GetFooQueryHandler getFooQueryHandler,
        GetFooByIdQueryHandler getFooByIdQueryHandler,
        GetFooByUserIdQueryHandler getFooByUserIdQueryHandler)
    {
        _createFooCommandHandler = createFooCommandHandler;
        _updateFooCommandHandler = updateFooCommandHandler;
        _deleteFooCommandHandler = deleteFooCommandHandler;
        _getFooQueryHandler = getFooQueryHandler;
        _getFooByIdQueryHandler = getFooByIdQueryHandler;
        _getFooByUserIdQueryHandler = getFooByUserIdQueryHandler;
    }

    public async Task<IList<FooDTO>> GetFooQueryAsync(CancellationToken cancellationToken)
    {
        var foo = await _getFooQueryHandler.HandleAsync(cancellationToken);

        return foo.Select(x => new FooDTO
        {
            Id = x.Id,
            Title = x.Title,
            IsCompleted = x.IsCompleted
        }).ToList();
    }

    public async Task<IList<FooDTO>> GetFooByIdQueryAsync(int id, CancellationToken cancellationToken)
    {
        var foo = await _getFooByIdQueryHandler.HandleAsync(id, cancellationToken);

        return foo.Select(x => new FooDTO
        {
            Id = x.Id,
            Title = x.Title,
            IsCompleted = x.IsCompleted
        }).ToList();
    }

    public async Task<IList<FooDTO>> GetFooByUserIdQueryAsync(string id, CancellationToken cancellationToken)
    {
        var foo = await _getFooByUserIdQueryHandler.HandleAsync(id, cancellationToken);

        return foo.Select(x => new FooDTO
        {
            Id = x.Id,
            Title = x.Title,
            IsCompleted = x.IsCompleted
        }).ToList();
    }

    public async Task AddFooAsync(FooRequest request, CancellationToken cancellationToken)
    {
        await _createFooCommandHandler.HandleAsync(request, cancellationToken);
    }

    public async Task UpdateFooAsync(FooRequest request, CancellationToken cancellationToken)
    {
        await _updateFooCommandHandler.HandleAsync(request, cancellationToken);
    }

    public async Task DeleteFooAsync(FooRequest request, CancellationToken cancellationToken)
    {
        await _deleteFooCommandHandler.Handle(request, cancellationToken);
    }
}