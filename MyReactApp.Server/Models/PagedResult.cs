namespace MyReactApp.Server.Models;

public class PagedResult<T>
{
    public int TotalCount { get; set; } // Total number of items
    public int PageNumber { get; set; } // Current page number
    public int PageSize { get; set; } // Number of items per page
    public IEnumerable<T> Items { get; set; } = new List<T>(); // Collection of items for the current page
}
