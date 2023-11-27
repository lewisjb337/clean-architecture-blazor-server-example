using Application.DTOs;
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
    }
}
