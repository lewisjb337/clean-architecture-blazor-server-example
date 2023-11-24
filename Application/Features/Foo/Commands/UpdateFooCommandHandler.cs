using Persistence.Repositories;

namespace Application.Features.Tasks.Commands;

public class UpdateFooCommandHandler
{
    private readonly IFooRepository _fooRepository;

    public UpdateFooCommandHandler(IFooRepository fooRepository)
    {
        _fooRepository = fooRepository;
    }

    public void Handle(UpdateFooCommand command)
    {
        var existingFoo = _fooRepository.GetFooById(command.Id);

        if (existingFoo != null)
        {
            existingFoo.Title = command.Title;
            existingFoo.IsCompleted = command.IsCompleted;
            _fooRepository.UpdateFoo(existingFoo);
        }
    }
}