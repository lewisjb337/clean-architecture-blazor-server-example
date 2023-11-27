using Domain.Entities.Foo;
using Persistence.Repositories;

namespace Application.Features.Foo.Commands.Create;

public class CreateFooCommandHandler
{
    private readonly IFooRepository _fooRepository;

    public CreateFooCommandHandler(IFooRepository fooRepository)
    {
        _fooRepository = fooRepository;
    }

    public void Handle(CreateFooCommand command)
    {
        var newFoo = new FooEntity { UserId = command.UserId, Title = command.Title, IsCompleted = false, CreatedAt = DateTimeOffset.Now };
        _fooRepository.AddFoo(newFoo);
    }
}