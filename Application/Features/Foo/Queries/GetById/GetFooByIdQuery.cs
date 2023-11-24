using Domain.Entities.Foo;

namespace Application.Features.Foo.Queries.GetById;

public class GetFooByIdQuery
{
    public int FooId { get; set; }
}

public class GetFooByIdQueryResult
{
    public FooEntity Foo { get; set; } = new FooEntity();
}