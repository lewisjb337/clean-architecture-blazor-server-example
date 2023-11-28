using Application.DTOs;
using Application.Features.Foo.Commands.Create;
using Application.Services.Foo;
using Microsoft.AspNetCore.Components;
using WebUI.Services;

namespace WebUI.Pages;

public partial class FooExample
{
    [Inject]
    public required IFooService FooService { get; set; }

    [Inject]
    public UserContext UserContext { get; set; }

    private IList<FooDTO>? UserFoos { get; set; }
    private IList<FooDTO>? Foos { get; set; }
    readonly string UserId = string.Empty;

    protected override async void OnInitialized()
    {
        await LoadData();
    }

    public async Task LoadData()
    {
        var user_id = await UserContext.UserId();

        UserFoos = await FooService.GetFooByUserIdQuery(user_id);

        Foos = await FooService.GetFooQuery();

        StateHasChanged();
    }

    public void AddData()
    {
        FooService.AddFoo(new CreateFooCommand
        {
            UserId = UserId,
            Title = "Foo",
        });

        StateHasChanged();
    }
}
