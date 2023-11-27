using Domain.Entities.Foo;
using Persistence.Repositories;

namespace Application.Features.Foo.Queries.GetById;

public class GetFooByUserIdQueryHandler
{
    private readonly IFooRepository _fooRepository;

    public GetFooByUserIdQueryHandler(IFooRepository fooRepository)
    {
        _fooRepository = fooRepository;
    }

    public async Task<IList<FooEntity>> Handle(string id)
    {
        return await _fooRepository.GetFooByUserId(id);
    }
}