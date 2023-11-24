using Application.Features.Tasks.Commands;
using Application.Features.Tasks.Queries;
using Domain.Entities;
using Persistence.Repositories;

namespace Application.Services;

public class FooService : IFooService
{
    private readonly IFooRepository _fooRepository;
    private readonly CreateFooCommandHandler _createFooCommandHandler;
    private readonly UpdateFooCommandHandler _updateFooCommandHandler;
    private readonly DeleteFooCommandHandler _deleteFooCommandHandler;
    private readonly GetFooQueryHandler _getFooQueryHandler;
    private readonly GetFooByIdQueryHandler _getFooByIdQueryHandler;

    public FooService(
        IFooRepository fooRepository,
        CreateFooCommandHandler createFooCommandHandler,
        UpdateFooCommandHandler updateFooCommandHandler,
        DeleteFooCommandHandler deleteFooCommandHandler,
        GetFooQueryHandler getFooQueryHandler,
        GetFooByIdQueryHandler getFooByIdQueryHandler)
    {
        _fooRepository = fooRepository;
        _createFooCommandHandler = createFooCommandHandler;
        _updateFooCommandHandler = updateFooCommandHandler;
        _deleteFooCommandHandler = deleteFooCommandHandler;
        _getFooQueryHandler = getFooQueryHandler;
        _getFooByIdQueryHandler = getFooByIdQueryHandler;
    }

    public List<Foo> GetFoos()
    {
        return _fooRepository.GetFoos();
    }

    public Foo GetFooById(int id)
    {
        return _fooRepository.GetFooById(id);
    }

    public void AddFoo(CreateFooCommand command)
    {
        _createFooCommandHandler.Handle(command);
    }

    public void UpdateFoo(UpdateFooCommand command)
    {
        _updateFooCommandHandler.Handle(command);
    }

    public void DeleteFoo(DeleteFooCommand command)
    {
        _deleteFooCommandHandler.Handle(command);
    }

    public List<Foo> GetFooQuery()
    {
        var result = _getFooQueryHandler.Handle();
        return result.Foos;
    }

    public Foo GetFooByIdQuery(int id)
    {
        var query = new GetFooByIdQuery { FooId = id };
        var result = _getFooByIdQueryHandler.Handle(query);
        return result.Foo;
    }
}