using Application.DTOs;
using Application.Services;
using Domain.Entities.Foo;
using Microsoft.AspNetCore.Components;

namespace WebUI.Pages;

public partial class FooExample
{
    [Inject]
    public required IFooService FooService { get; set; }

    private List<FooDTO> foos = new();
    private FooEntity? selectedFoo;

    protected override void OnInitialized()
    {
        foos = FooService.GetFooQuery();
    }

    private void GetFooDetails(int fooId)
    {
        selectedFoo = FooService.GetFooByIdQuery(fooId);
    }
}
