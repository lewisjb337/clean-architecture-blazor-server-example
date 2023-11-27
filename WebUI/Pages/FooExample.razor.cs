using Application.DTOs;
using Application.Features.Foo.Commands.Create;
using Application.Services;
using Microsoft.AspNetCore.Components;

namespace WebUI.Pages;

public partial class FooExample
{
    [Inject]
    public required IFooService FooService { get; set; }

    private IList<FooDTO>? foos { get; set; }

    protected override void OnInitialized()
    {
        LoadData();
    }

    public async void LoadData()
    {
        foos = await FooService.GetFooQuery();

        StateHasChanged();
    }

    public async void AddData()
    {
        FooService.AddFoo(new CreateFooCommand
        {
            Title = "Foo",
        });

        StateHasChanged();
    }
}
