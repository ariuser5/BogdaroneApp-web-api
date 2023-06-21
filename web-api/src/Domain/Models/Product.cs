namespace BogdaroneApp.Domain.Models;

public record Product
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? ImageId { get; set; }
    public string? Description { get; set; }
}
