namespace BogdaroneApp.Domain.Models;

public record Image
{
    public string? Id { get; set; }
    public byte[]? Bytes { get; set; }
}