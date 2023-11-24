using Domain.Entities.Foo;

namespace Persistence.Repositories;

public class FooRepository : IFooRepository
{
    private static readonly List<FooEntity> _Foos = new();

    public List<FooEntity> GetFoos(CancellationToken cancellationToken)
    {
        return _Foos;
    }

    public FooEntity GetFooById(int id, CancellationToken cancellationToken)
    {
        var foo = _Foos.FirstOrDefault(t => t.Id == id);

        if (foo is not null)
            return foo;
        else
            throw new NullReferenceException($"Could not find data for Foo with id: {id}");
    }

    public void AddFoo(FooEntity Foo, CancellationToken cancellationToken)
    {
        _Foos.Add(Foo);
    }

    public void UpdateFoo(FooEntity Foo, CancellationToken cancellationToken)
    {
        var existingFoo = _Foos.FirstOrDefault(t => t.Id == Foo.Id);
        if (existingFoo != null)
        {
            existingFoo.Title = Foo.Title;
            existingFoo.IsCompleted = Foo.IsCompleted;
        }
    }

    public void DeleteFoo(int id, CancellationToken cancellationToken)
    {
        var FooToRemove = _Foos.FirstOrDefault(t => t.Id == id);
        if (FooToRemove != null)
        {
            _Foos.Remove(FooToRemove);
        }
    }
}