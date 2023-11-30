using Application.DTOs;
using Models.Requests;

namespace Application.Services.Foo;

public interface IFooService
{
    Task<IList<FooDTO>> GetFooQueryAsync(CancellationToken cancellationToken = default);
    Task<IList<FooDTO>> GetFooByIdQueryAsync(int id, CancellationToken cancellationToken = default);
    Task<IList<FooDTO>> GetFooByUserIdQueryAsync(string id, CancellationToken cancellationToken = default);
    Task AddFooAsync(FooRequest request, CancellationToken cancellationToken = default);
    Task UpdateFooAsync(FooRequest request, CancellationToken cancellationToken = default);
    Task DeleteFooAsync(FooRequest request, CancellationToken cancellationToken = default);
}