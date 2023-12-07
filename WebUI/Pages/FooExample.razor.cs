using Application.Entities.Requests;
using Application.Entities.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Persistence.Services;
using Request.Handlers.Concrete.Interfaces;

namespace WebUI.Pages;

[Authorize]
public partial class FooExample
{
    [Inject]
    public required IRequestHandler Handler { get; set; }

    [Inject]
    public UserContext? UserContext { get; set; }

    public IList<FooResponse>? Foos { get; set; } 

    string UserId = string.Empty;

    protected override async void OnInitialized()
    {
        await LoadData();
    }

    public async Task LoadData(CancellationToken cancellationToken = default)
    {
        var user_id = string.Empty;

        if(UserContext is not null)
            user_id = await UserContext.UserId();

        if(user_id is not null)
            UserId = user_id;

        Foos = await Handler.ExecuteAsync<GetFooRequest, IList<FooResponse>>(new GetFooRequest {}, cancellationToken);

        StateHasChanged();
    }

    public async Task AddData(CancellationToken cancellationToken = default)
    {
        await Handler.ExecuteAsync<CreateFooRequest, FooResponse>(new CreateFooRequest
        {
            UserId = UserId,
            Title = "Foo",
        }, cancellationToken);

        await LoadData(cancellationToken);
    }
}
