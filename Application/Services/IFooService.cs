using Application.DTOs;
using Application.Features.Foo.Commands.Create;
using Application.Features.Foo.Commands.Delete;
using Application.Features.Foo.Commands.Update;
using Domain.Entities.Foo;

namespace Application.Services;

public interface IFooService
{
    List<FooDTO> GetFooQuery(CancellationToken cancellationToken = default);
    FooEntity GetFooByIdQuery(int id, CancellationToken cancellationToken = default);
    void AddFoo(CreateFooCommand command, CancellationToken cancellationToken = default);
    void UpdateFoo(UpdateFooCommand command, CancellationToken cancellationToken = default);
    void DeleteFoo(DeleteFooCommand command, CancellationToken cancellationToken = default);
}