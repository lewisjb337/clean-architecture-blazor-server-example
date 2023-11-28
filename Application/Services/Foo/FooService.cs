using Application.DTOs;
using Application.Features.Foo.Commands.Create;
using Application.Features.Foo.Commands.Delete;
using Application.Features.Foo.Commands.Update;
using Application.Features.Foo.Queries.Get;
using Application.Features.Foo.Queries.GetById;

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
        var foo = await _getFooQueryHandler.HandleAsync();

        return foo.Select(x => new FooDTO
        {
            Id = x.Id,
            Title = x.Title,
            IsCompleted = x.IsCompleted
        }).ToList();
    }

    public async Task<IList<FooDTO>> GetFooByIdQueryAsync(int id, CancellationToken cancellationToken)
    {
        var foo = await _getFooByIdQueryHandler.HandleAsync(id);

        return foo.Select(x => new FooDTO
        {
            Id = x.Id,
            Title = x.Title,
            IsCompleted = x.IsCompleted
        }).ToList();
    }

    public async Task<IList<FooDTO>> GetFooByUserIdQueryAsync(string id, CancellationToken cancellationToken)
    {
        var foo = await _getFooByUserIdQueryHandler.HandleAsync(id);

        return foo.Select(x => new FooDTO
        {
            Id = x.Id,
            Title = x.Title,
            IsCompleted = x.IsCompleted
        }).ToList();
    }

    public async Task AddFooAsync(CreateFooCommand command, CancellationToken cancellationToken)
    {
        await _createFooCommandHandler.HandleAsync(command);
    }

    public async Task UpdateFooAsync(UpdateFooCommand command, CancellationToken cancellationToken)
    {
        await _updateFooCommandHandler.HandleAsync(command);
    }

    public void DeleteFooAsync(DeleteFooCommand command, CancellationToken cancellationToken)
    {
        _deleteFooCommandHandler.Handle(command);
    }
}