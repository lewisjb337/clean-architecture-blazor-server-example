using Application.DTOs;
using Application.Features.Foo.Commands.Create;
using Application.Features.Foo.Commands.Delete;
using Application.Features.Foo.Commands.Update;

namespace Application.Services.Foo;

public interface IFooService
{
    Task<IList<FooDTO>> GetFooQueryAsync(CancellationToken cancellationToken = default);
    Task<IList<FooDTO>> GetFooByIdQueryAsync(int id, CancellationToken cancellationToken = default);
    Task<IList<FooDTO>> GetFooByUserIdQueryAsync(string id, CancellationToken cancellationToken = default);
    Task AddFooAsync(CreateFooCommand command, CancellationToken cancellationToken = default);
    Task UpdateFooAsync(UpdateFooCommand command, CancellationToken cancellationToken = default);
    void DeleteFooAsync(DeleteFooCommand command, CancellationToken cancellationToken = default);
}