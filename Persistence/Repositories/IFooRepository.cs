using Domain.Entities;

namespace Persistence.Repositories;

public interface IFooRepository
{
    List<Foo> GetFoos();
    Foo GetFooById(int id);
    void AddFoo(Foo foo);
    void UpdateFoo(Foo foo);
    void DeleteFoo(int id);
}