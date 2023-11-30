using Application.DTOs;
using Microsoft.Extensions.Logging;
using Models.Requests;
using Persistence.Features.Foo.Commands.Create;
using Persistence.Features.Foo.Commands.Delete;
using Persistence.Features.Foo.Commands.Update;
using Persistence.Features.Foo.Queries.Get;
using Persistence.Features.Foo.Queries.GetById;
using Persistence.Services;

namespace Application.Services.Foo;

public class FooService : IFooService
{
    private readonly CreateFooHandler _createFooCommandHandler;
    private readonly UpdateFooHandler _updateFooCommandHandler;
    private readonly DeleteFooHandler _deleteFooCommandHandler;
    private readonly GetFooHandler _getFooQueryHandler;
    private readonly GetFooByIdHandler _getFooByIdQueryHandler;
    private readonly GetFooByUserIdHandler _getFooByUserIdQueryHandler;

    private readonly UserContext _userContext;

    private readonly ILogger<FooService> _logger;

    public FooService(
        CreateFooHandler createFooCommandHandler,
        UpdateFooHandler updateFooCommandHandler,
        DeleteFooHandler deleteFooCommandHandler,
        GetFooHandler getFooQueryHandler,
        GetFooByIdHandler getFooByIdQueryHandler,
        GetFooByUserIdHandler getFooByUserIdQueryHandler,
        UserContext userContext,
        ILogger<FooService> logger)
    {
        _createFooCommandHandler = createFooCommandHandler;
        _updateFooCommandHandler = updateFooCommandHandler;
        _deleteFooCommandHandler = deleteFooCommandHandler;
        _getFooQueryHandler = getFooQueryHandler;
        _getFooByIdQueryHandler = getFooByIdQueryHandler;
        _getFooByUserIdQueryHandler = getFooByUserIdQueryHandler;
        _userContext = userContext;
        _logger = logger;
    }

    public async Task<IList<FooDTO>> GetFooQueryAsync(CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Attempting to get all Foo");

            var foos = await _getFooQueryHandler.HandleAsync(cancellationToken);

            if (foos is null)
                throw new Exception($"Could not find any Foo");


            List<FooDTO> fooList = new();

            foreach (var foo in foos)
            {
                var username = foo.UserId != null ? _userContext.Username(foo.UserId).Result.ToString() : null;

                fooList.Add(new FooDTO
                {
                    Id = foo.Id,
                    Username = username,
                    Title = foo.Title,
                    IsCompleted = foo.IsCompleted
                });
            }

            return fooList;
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Failed to get all Foo");
            throw;
        }
    }

    public async Task<IList<FooDTO>> GetFooByIdQueryAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Attempting to get Foo by id: {id}");

            var foo = await _getFooByIdQueryHandler.HandleAsync(id, cancellationToken);

            if (foo is null)
                throw new Exception($"Could not find any Foo with id: {id}");

            return foo.Select(x => new FooDTO
            {
                Id = x.Id,
                Title = x.Title,
                IsCompleted = x.IsCompleted
            }).ToList();
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Failed to get Foo by id: {id}");
            throw;
        }
    }

    public async Task<IList<FooDTO>> GetFooByUserIdQueryAsync(string id, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Attempting to get Foo by user id: {id}");

            var foo = await _getFooByUserIdQueryHandler.HandleAsync(id, cancellationToken);

            if (foo is null)
                throw new Exception($"Could not find any Foo with user id: {id}");

            return foo.Select(x => new FooDTO
            {
                Id = x.Id,
                Title = x.Title,
                IsCompleted = x.IsCompleted
            }).ToList();
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Failed to get Foo by user id: {id}");
            throw;
        }
    }

    public async Task AddFooAsync(FooRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Attempting to create Foo: {request}");
            
            await _createFooCommandHandler.HandleAsync(request, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Failed to create Foo: {request}");
            throw;
        }
    }

    public async Task UpdateFooAsync(FooRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Attempting to update Foo: {request}");

            await _updateFooCommandHandler.HandleAsync(request, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Failed to update Foo:{request}");
            throw;
        }
    }

    public async Task DeleteFooAsync(FooRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Attempting to delete Foo: {request}");

            await _deleteFooCommandHandler.Handle(request, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Failed to delete Foo: {request}");
            throw;
        }
    }
}