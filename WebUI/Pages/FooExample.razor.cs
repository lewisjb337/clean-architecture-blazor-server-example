using Application.DTOs;
using Application.Features.Foo.Commands.Create;
using Application.Services;
using Microsoft.AspNetCore.Components;
using WebUI.Services;

namespace WebUI.Pages;

public partial class FooExample
{
    [Inject]
    public required IFooService FooService { get; set; }

    [Inject]
    public UserContext UserContext { get; set; }

    private IList<FooDTO>? userFoos { get; set; }
    private IList<FooDTO>? foos { get; set; }
    string UserId = string.Empty;

    protected override async void OnInitialized()
    {
        LoadData();
    }

    public async void LoadData()
    {
        var user_id = await UserContext.UserId();

        userFoos = await FooService.GetFooByUserIdQuery(user_id);

        foos = await FooService.GetFooQuery();

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
