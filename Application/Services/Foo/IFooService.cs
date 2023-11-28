using Application.DTOs;
using Application.Features.Foo.Commands.Create;
using Application.Features.Foo.Commands.Delete;
using Application.Features.Foo.Commands.Update;

namespace Application.Services.Foo;

public interface IFooService
{
    Task<IList<FooDTO>> GetFooQuery(CancellationToken cancellationToken = default);
    Task<IList<FooDTO>> GetFooByIdQuery(int id, CancellationToken cancellationToken = default);
    Task<IList<FooDTO>> GetFooByUserIdQuery(string id, CancellationToken cancellationToken = default);
    void AddFoo(CreateFooCommand command, CancellationToken cancellationToken = default);
    void UpdateFoo(UpdateFooCommand command, CancellationToken cancellationToken = default);
    void DeleteFoo(DeleteFooCommand command, CancellationToken cancellationToken = default);
}