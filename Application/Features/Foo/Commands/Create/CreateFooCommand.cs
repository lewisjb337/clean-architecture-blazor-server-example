namespace Application.Features.Foo.Commands.Create;

public class CreateFooCommand
{
    public string UserId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
}