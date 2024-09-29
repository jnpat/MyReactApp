namespace MyReactApp.Server.Models.DTOs;

public class ImageDto
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Alt { get; set; } = null!;

    public string Original { get; set; } = null!;
}
