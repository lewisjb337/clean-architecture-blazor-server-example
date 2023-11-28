using Domain.Entities.Foo;
using Persistence.Repositories;

namespace Application.Features.Foo.Queries.Get;

public class GetFooQueryHandler
{
    private readonly IFooRepository _fooRepository;

    public GetFooQueryHandler(IFooRepository fooRepository)
    {
        _fooRepository = fooRepository;
    }

    public async Task<IList<FooEntity>> HandleAsync()
    {
        return await _fooRepository.GetFoosAsync();
    }
}
