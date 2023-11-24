using Persistence.Repositories;

namespace Application.Features.Tasks.Queries;

public class GetFooByIdQueryHandler
{
    private readonly IFooRepository _fooRepository;

    public GetFooByIdQueryHandler(IFooRepository fooRepository)
    {
        _fooRepository = fooRepository;
    }

    public GetFooByIdQueryResult Handle(GetFooByIdQuery query)
    {
        var task = _fooRepository.GetFooById(query.FooId);
        return new GetFooByIdQueryResult { Foo = task };
    }
}