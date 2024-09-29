namespace MyReactApp.Server.Models.Parameters;

public class ProductQueryParameters
{
    // Pagination properties
    public int PageNumber { get; set; } = 1; // Default page number
    public int PageSize { get; set; } = 10;  // Default items per page

    // Sorting properties
    public string SortBy { get; set; } = "Id";  // Default sort by id
    public string SortOrder { get; set; } = "asc"; // Default sort order

    // Filtering properties
    public string? NameFilter { get; set; }  // Filter by name
}
