using Application.Features.Tasks.Commands;
using Domain.Entities;

namespace Application.Services;

public interface IFooService
{
    List<Foo> GetFoos();
    Foo GetFooById(int id);
    void AddFoo(CreateFooCommand command);
    void UpdateFoo(UpdateFooCommand command);
    void DeleteFoo(DeleteFooCommand command);

    List<Foo> GetFooQuery();
    Foo GetFooByIdQuery(int id);
}