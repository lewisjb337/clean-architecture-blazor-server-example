using Domain.Entities;

namespace Persistence.Repositories;

public class FooRepository : IFooRepository
{
    private static readonly List<Foo> _Foos = new();

    public List<Foo> GetFoos()
    {
        return _Foos;
    }

    public Foo GetFooById(int id)
    {
        var foo = _Foos.FirstOrDefault(t => t.Id == id);

        if (foo is not null)
            return foo;
        else
            throw new NullReferenceException($"Could not find data for Foo with id: {id}");
    }

    public void AddFoo(Foo Foo)
    {
        _Foos.Add(Foo);
    }

    public void UpdateFoo(Foo Foo)
    {
        var existingFoo = _Foos.FirstOrDefault(t => t.Id == Foo.Id);
        if (existingFoo != null)
        {
            existingFoo.Title = Foo.Title;
            existingFoo.IsCompleted = Foo.IsCompleted;
        }
    }

    public void DeleteFoo(int id)
    {
        var FooToRemove = _Foos.FirstOrDefault(t => t.Id == id);
        if (FooToRemove != null)
        {
            _Foos.Remove(FooToRemove);
        }
    }
}