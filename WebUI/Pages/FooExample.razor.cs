using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace WebUI.Pages;

public partial class FooExample
{
    [Inject]
    public required IFooService FooService { get; set; }

    private List<Foo> foos = new();
    private Foo? selectedFoo;

    protected override void OnInitialized()
    {
        foos = FooService.GetFooQuery();
    }

    private void GetFooDetails(int fooId)
    {
        selectedFoo = FooService.GetFooByIdQuery(fooId);
    }
}
