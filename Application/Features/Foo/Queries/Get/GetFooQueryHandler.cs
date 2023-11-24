using Application.Features.Tasks.Queries;
using Persistence.Repositories;

namespace Application.Features.Foo.Queries.Get;

public class GetFooQueryHandler
{
    private readonly IFooRepository _fooRepository;

    public GetFooQueryHandler(IFooRepository fooRepository)
    {
        _fooRepository = fooRepository;
    }

    public GetFoosQueryResult Handle()
    {
        var foos = _fooRepository.GetFoos();
        return new GetFoosQueryResult { Foos = foos };
    }
}
