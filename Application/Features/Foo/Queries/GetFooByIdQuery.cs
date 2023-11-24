using Domain.Entities;

namespace Application.Features.Tasks.Queries;

public class GetFooByIdQuery
{
    public int FooId { get; set; }
}

public class GetFooByIdQueryResult
{
    public Foo Foo { get; set; } = new Foo();
}