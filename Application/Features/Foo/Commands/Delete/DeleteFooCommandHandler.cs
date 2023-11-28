using Persistence.Repositories;

namespace Application.Features.Foo.Commands.Delete;

public class DeleteFooCommandHandler
{
    private readonly IFooRepository _fooRepository;

    public DeleteFooCommandHandler(IFooRepository fooRepository)
    {
        _fooRepository = fooRepository;
    }

    public void Handle(DeleteFooCommand command)
    {
        _fooRepository.DeleteFooAsync(command.Id);
    }
}