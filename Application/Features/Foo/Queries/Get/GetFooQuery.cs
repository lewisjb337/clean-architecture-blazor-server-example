using Domain.Entities.Foo;

namespace Application.Features.Tasks.Queries;

public class GetFoosQuery
{
}

public class GetFoosQueryResult
{
    public List<FooEntity> Foos { get; set; } = new List<FooEntity>();
}