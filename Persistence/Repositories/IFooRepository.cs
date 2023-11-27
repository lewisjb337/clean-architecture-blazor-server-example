using Domain.Entities.Foo;

namespace Persistence.Repositories;

public interface IFooRepository
{
    Task<IList<FooEntity>> GetFoos(CancellationToken cancellationToken = default);
    Task<IList<FooEntity>> GetFooById(int id, CancellationToken cancellationToken = default);
    void AddFoo(FooEntity foo, CancellationToken cancellationToken = default);
    void UpdateFoo(FooEntity foo, CancellationToken cancellationToken = default);
    void DeleteFoo(int id, CancellationToken cancellationToken = default);
}