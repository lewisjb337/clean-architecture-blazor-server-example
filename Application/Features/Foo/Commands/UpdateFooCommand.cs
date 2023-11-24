namespace Application.Features.Tasks.Commands;

public class UpdateFooCommand
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}