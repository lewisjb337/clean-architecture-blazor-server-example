using Models.Requests;
using Persistence.Contexts;

namespace Persistence.Features.Foo.Commands.Update;

public class UpdateFooHandler
{
    private readonly ApplicationDbContext _context;

    public UpdateFooHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task HandleAsync(FooRequest command, CancellationToken cancellationToken)
    {
        var foo = _context.Foo.FirstOrDefault(x => x.Id.Equals(command.Id));

        if(foo is not null)
        {
            foo.Title = command.Title;
            foo.IsCompleted = command.IsCompleted;
            foo.UpdatedAt = DateTimeOffset.Now;

            var changes = await _context.SaveChangesAsync(cancellationToken);

            if (changes <= 0)
                throw new Exception($"Failed to save changes for update to: {foo}");
        }
        else
        {
            throw new Exception($"Could not find Foo by id: {command.Id}");
        }
    }
}