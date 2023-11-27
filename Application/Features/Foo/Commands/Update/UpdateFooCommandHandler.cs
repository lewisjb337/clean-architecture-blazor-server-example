using Persistence.Repositories;

namespace Application.Features.Foo.Commands.Update;

public class UpdateFooCommandHandler
{
    private readonly IFooRepository _fooRepository;

    public UpdateFooCommandHandler(IFooRepository fooRepository)
    {
        _fooRepository = fooRepository;
    }

    public async void Handle(UpdateFooCommand command)
    {
        var existingFoo = await _fooRepository.GetFooById(command.Id);

        if (existingFoo is not null)
        {
            var foo = existingFoo.FirstOrDefault();

            foo.Title = command.Title;
            foo.IsCompleted = command.IsCompleted;
            foo.UpdatedAt = DateTimeOffset.Now;

            _fooRepository.UpdateFoo(foo);
        }
    }
}