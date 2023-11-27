using Domain.Entities.Foo;
using Persistence.Repositories;

namespace Application.Features.Foo.Queries.GetById;

public class GetFooByIdQueryHandler
{
    private readonly IFooRepository _fooRepository;

    public GetFooByIdQueryHandler(IFooRepository fooRepository)
    {
        _fooRepository = fooRepository;
    }

    public async Task<IList<FooEntity>> Handle(int id)
    {
        return await _fooRepository.GetFooById(id);
    }
}