namespace MyReactApp.Server.Data;

public class ApiResponse
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public List<OProduct> Products { get; set; }  // This matches the "products" array in the JSON
}
