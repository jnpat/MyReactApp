namespace MyReactApp.Server.Models.DTOs;

public class PriceDto
{
    public decimal Amount { get; set; }
    public string Currency { get; set; } = null!;
}
