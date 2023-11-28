using Domain.Entities.Foo;

namespace Persistence.Repositories;

public interface IFooRepository
{
    Task<IList<FooEntity>> GetFoosAsync(CancellationToken cancellationToken = default);
    Task<IList<FooEntity>> GetFooByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IList<FooEntity>> GetFooByUserIdAsync(string id, CancellationToken cancellationToken = default);
    Task AddFooAsync(FooEntity foo, CancellationToken cancellationToken = default);
    Task UpdateFooAsync(FooEntity foo, CancellationToken cancellationToken = default);
    void DeleteFooAsync(int id, CancellationToken cancellationToken = default);
}