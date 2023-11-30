using Application.DTOs;
using Application.Services.Foo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Models.Requests;
using WebUI.Services;

namespace WebUI.Pages;

[Authorize]
public partial class FooExample
{
    [Inject]
    public required IFooService FooService { get; set; }

    [Inject]
    public UserContext? UserContext { get; set; }

    private IList<FooDTO>? Foos { get; set; }

    string UserId = string.Empty;

    protected override async void OnInitialized()
    {
        await LoadData();
    }

    public async Task LoadData()
    {
        var user_id = string.Empty;

        if(UserContext is not null)
            user_id = await UserContext.UserId();

        if(user_id is not null)
            UserId = user_id;

        Foos = await FooService.GetFooQueryAsync();

        StateHasChanged();
    }

    public async Task AddData()
    {
        await FooService.AddFooAsync(new FooRequest
        {
            UserId = UserId,
            Title = "Foo",
        });

        await LoadData();
    }
}
