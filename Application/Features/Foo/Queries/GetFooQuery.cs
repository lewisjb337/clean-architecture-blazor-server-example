using Domain.Entities;

namespace Application.Features.Tasks.Queries;

public class GetFoosQuery
{
}

public class GetFoosQueryResult
{
    public List<Foo> Foos { get; set; } = new List<Foo>();
}