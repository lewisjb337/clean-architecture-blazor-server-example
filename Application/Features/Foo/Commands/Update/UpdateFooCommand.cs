namespace Application.Features.Foo.Commands.Update;

public class UpdateFooCommand
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}