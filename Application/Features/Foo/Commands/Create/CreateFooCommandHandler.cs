using Domain.Entities;
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
        var newFoo = new Foo { Title = command.Title, IsCompleted = false };
        _fooRepository.AddFoo(newFoo);
    }
}