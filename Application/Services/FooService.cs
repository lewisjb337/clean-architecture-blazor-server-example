using Application.DTOs;
using Application.Features.Foo.Commands.Create;
using Application.Features.Foo.Commands.Delete;
using Application.Features.Foo.Commands.Update;
using Application.Features.Foo.Queries.Get;
using Application.Features.Foo.Queries.GetById;
using Domain.Entities.Foo;
using Persistence.Repositories;

namespace Application.Services;

public class FooService : IFooService
{
    private readonly CreateFooCommandHandler _createFooCommandHandler;
    private readonly UpdateFooCommandHandler _updateFooCommandHandler;
    private readonly DeleteFooCommandHandler _deleteFooCommandHandler;
    private readonly GetFooQueryHandler _getFooQueryHandler;
    private readonly GetFooByIdQueryHandler _getFooByIdQueryHandler;

    public FooService(
        CreateFooCommandHandler createFooCommandHandler,
        UpdateFooCommandHandler updateFooCommandHandler,
        DeleteFooCommandHandler deleteFooCommandHandler,
        GetFooQueryHandler getFooQueryHandler,
        GetFooByIdQueryHandler getFooByIdQueryHandler)
    {
        _createFooCommandHandler = createFooCommandHandler;
        _updateFooCommandHandler = updateFooCommandHandler;
        _deleteFooCommandHandler = deleteFooCommandHandler;
        _getFooQueryHandler = getFooQueryHandler;
        _getFooByIdQueryHandler = getFooByIdQueryHandler;
    }

    public List<FooDTO> GetFooQuery(CancellationToken cancellationToken)
    {
        var result = _getFooQueryHandler.Handle();
        return result.Foos.Select(x => new FooDTO
        {
            Id = x.Id,
            Title = x.Title,
            IsCompleted = x.IsCompleted
        }).ToList();
    }

    public FooEntity GetFooByIdQuery(int id, CancellationToken cancellationToken)
    {
        var query = new GetFooByIdQuery { FooId = id };
        var result = _getFooByIdQueryHandler.Handle(query);
        return result.Foo;
    }

    public void AddFoo(CreateFooCommand command, CancellationToken cancellationToken)
    {
        _createFooCommandHandler.Handle(command);
    }

    public void UpdateFoo(UpdateFooCommand command, CancellationToken cancellationToken)
    {
        _updateFooCommandHandler.Handle(command);
    }

    public void DeleteFoo(DeleteFooCommand command, CancellationToken cancellationToken)
    {
        _deleteFooCommandHandler.Handle(command);
    }
}