using Persistence.Repositories;

namespace Application.Features.Tasks.Queries;

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
