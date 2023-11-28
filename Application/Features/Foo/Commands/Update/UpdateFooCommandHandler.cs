using Persistence.Repositories;

namespace Application.Features.Foo.Commands.Update;

public class UpdateFooCommandHandler
{
    private readonly IFooRepository _fooRepository;

    public UpdateFooCommandHandler(IFooRepository fooRepository)
    {
        _fooRepository = fooRepository;
    }

    public async Task HandleAsync(UpdateFooCommand command)
    {
        var existingFoo = await _fooRepository.GetFooByIdAsync(command.Id);

        if (existingFoo is not null)
        {
            var foo = existingFoo.FirstOrDefault();

            if(foo is not null)
            {
                foo.Title = command.Title;
                foo.IsCompleted = command.IsCompleted;
                foo.UpdatedAt = DateTimeOffset.Now;

                await _fooRepository.UpdateFooAsync(foo);
            }
        }
    }
}