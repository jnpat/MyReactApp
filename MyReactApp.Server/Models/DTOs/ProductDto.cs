namespace MyReactApp.Server.Models.DTOs;

public class ProductDto
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public PriceDto Price { get; set; } = null!;
    public List<ImageDto> Images { get; set; } = null!;
}
