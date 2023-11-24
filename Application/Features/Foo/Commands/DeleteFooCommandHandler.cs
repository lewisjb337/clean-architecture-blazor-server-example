using Persistence.Repositories;

namespace Application.Features.Tasks.Commands;

public class DeleteFooCommandHandler
{
    private readonly IFooRepository _fooRepository;

    public DeleteFooCommandHandler(IFooRepository fooRepository)
    {
        _fooRepository = fooRepository;
    }

    public void Handle(DeleteFooCommand command)
    {
        _fooRepository.DeleteFoo(command.Id);
    }
}