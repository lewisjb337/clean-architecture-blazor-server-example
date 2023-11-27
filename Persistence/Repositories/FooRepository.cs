using Domain.Entities.Foo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class FooRepository : IFooRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<FooRepository> _logger;

    public FooRepository(ApplicationDbContext context, ILogger<FooRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IList<FooEntity>> GetFoos(CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Attempting to get all foos");

            return await _context.Foo
                .Select(x => new FooEntity
                {
                    Id = x.Id,
                    Title = x.Title,
                    IsCompleted = x.IsCompleted,
                    CreatedAt = x.CreatedAt
                }).ToListAsync(cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Failed to get all foos");
            throw;
        }
    }

    public async Task<IList<FooEntity>> GetFooById(int id, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Attempting to get all foos");

            return await _context.Foo
                .Where(x => x.Id == id)
                .Select(x => new FooEntity
                {
                    Id = x.Id,
                    Title = x.Title,
                    IsCompleted = x.IsCompleted,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt
                }).ToListAsync(cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Failed to get all foos");
            throw;
        }
    }

    public async Task<IList<FooEntity>> GetFooByUserId(string id, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Attempting to get foos for user with id: {id}");

            return await _context.Foo
                .Where(x => x.UserId.Equals(id))
                .Select(x => new FooEntity
                {
                    Id = x.Id,
                    Title = x.Title,
                    IsCompleted = x.IsCompleted,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt
                }).ToListAsync(cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Failed to get foos for user with id: {id}");
            throw;
        }
    }

    public async void AddFoo(FooEntity foo, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Attempting to create new foo: {foo}");

            // You may or may not need this check, use as needed
            var exists = _context.Foo.FirstOrDefault(x => x.Id == foo.Id);

            // Same for this check, use as needed
            if (exists is not null)
                throw new Exception($"Could not create new foo: {foo}, as this already exists");

            var entity = await _context.Foo.AddAsync(new FooEntity
            {
                UserId = foo.UserId,
                Title = foo.Title,
                IsCompleted = foo.IsCompleted
            });

            var changes = await _context.SaveChangesAsync(cancellationToken);

            if (changes <= 0)
                throw new Exception($"Failed to create new foo: {foo}, while saving changes");
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Failed to create new foo: {foo}");
        }
    }

    public async void UpdateFoo(FooEntity foo, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Attempting to update foo with id: {foo.Id}");

            var fooObject = _context.Foo
                .AsTracking()
                .FirstOrDefault(x => x.Id == foo.Id);

            if (fooObject is null)
                throw new Exception($"Could not find foo with id: {foo.Id}");

            foo.Title = fooObject.Title;
            foo.IsCompleted = fooObject.IsCompleted;
            foo.UpdatedAt = fooObject.UpdatedAt;

            var changes = await _context.SaveChangesAsync(cancellationToken);

            if(changes <= 0)
                throw new Exception($"Failed to save changes whilst updating foo: {foo}");
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Failed to update foo with id: {foo.Id}");
            throw;
        }
    }

    public void DeleteFoo(int id, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Attempting to delete foo by id: {id}");

            var fooExists = _context.Foo.FirstOrDefault(x => x.Id == id);

            if (fooExists is null)
                throw new Exception($"Could not find foo with id: {id}");

            _context.Foo
                .Where(x => x.Id == id)
                .ExecuteDelete();
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Failed to delete foo with id: {id}");
            throw;
        }
    }
}