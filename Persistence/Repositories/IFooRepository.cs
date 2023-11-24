using Domain.Entities.Foo;

namespace Persistence.Repositories;

public interface IFooRepository
{
    List<FooEntity> GetFoos(CancellationToken cancellationToken = default);
    FooEntity GetFooById(int id, CancellationToken cancellationToken = default);
    void AddFoo(FooEntity foo, CancellationToken cancellationToken = default);
    void UpdateFoo(FooEntity foo, CancellationToken cancellationToken = default);
    void DeleteFoo(int id, CancellationToken cancellationToken = default);
}