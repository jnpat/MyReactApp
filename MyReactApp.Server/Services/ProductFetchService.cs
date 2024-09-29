using MyReactApp.Server.Data;

namespace MyReactApp.Server.Services;

public class ProductFetchService
{
    private readonly HttpClient _httpClient;

    public ProductFetchService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<OProduct>> FetchProducts(int page, int pageSize)
    {
        var url = "https://tabledusud.nl/_product/simpleFilters";
        var body = new { Page = page, PageSize = pageSize };
        var response = await _httpClient.PostAsJsonAsync(url, body);

        if (response.IsSuccessStatusCode)
        {
            try
            {
                var data = await response.Content.ReadFromJsonAsync<ApiResponse>();
                return data?.Products ?? new List<OProduct>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        return new List<OProduct>();
    }
}
