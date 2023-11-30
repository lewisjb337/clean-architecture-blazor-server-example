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
    private readonly CreateFooHandler _createFooCommandHandler;
    private readonly UpdateFooHandler _updateFooCommandHandler;
    private readonly DeleteFooHandler _deleteFooCommandHandler;
    private readonly GetFooHandler _getFooQueryHandler;
    private readonly GetFooByIdHandler _getFooByIdQueryHandler;
    private readonly GetFooByUserIdHandler _getFooByUserIdQueryHandler;

    public FooService(
        CreateFooHandler createFooCommandHandler,
        UpdateFooHandler updateFooCommandHandler,
        DeleteFooHandler deleteFooCommandHandler,
        GetFooHandler getFooQueryHandler,
        GetFooByIdHandler getFooByIdQueryHandler,
        GetFooByUserIdHandler getFooByUserIdQueryHandler)
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