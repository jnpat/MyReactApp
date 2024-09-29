using MyReactApp.Server.Models.DTOs;
using MyReactApp.Server.Models.Parameters;
using MyReactApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace MyReactApp.Server.Services;

public class ProductGetService
{
    private readonly ShopDbContext _dbContext;

    public ProductGetService(ShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PagedResult<ProductDto>> GetProductsAsync(ProductQueryParameters query)
    {
        // Build the query
        var productQuery = _dbContext.Products.AsQueryable();

        // Apply filter
        if (!string.IsNullOrWhiteSpace(query.NameFilter))
        {
            productQuery = productQuery.Where(p => p.Name.ToLower().Contains(query.NameFilter.ToLower()));
        }

        // Apply sorting
        productQuery = query.SortBy.ToLower() switch
        {
            "createddate" => productQuery.OrderBy(p => p.CreatedDate),
            "name" => productQuery.OrderBy(p => p.Name),
            _ => productQuery.OrderBy(p => p.Id),
        };

        // Get total count for pagination
        var totalItems = await productQuery.CountAsync();

        // Apply pagination
        var products = await productQuery
            .Skip((query.PageNumber - 1) * query.PageSize)
            .Take(query.PageSize)
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                CreatedDate = p.CreatedDate,
                Images = p.ProductImages.Select(i => new ImageDto
                {
                    Name = i.Image.Name,
                    Description = i.Image.Description,
                    Alt = i.Image.Alt,
                    Original = i.Image.Original,
                }).ToList(),
                Price = p.Prices.Where(pr => pr.ProductId == p.Id)
                .Select(pr => new PriceDto
                {
                    Amount = pr.Amount,
                    Currency = pr.Currency
                })
                .FirstOrDefault(),

            })
            .ToListAsync();

        return new PagedResult<ProductDto>
        {
            TotalCount = totalItems,
            PageNumber = query.PageNumber,
            PageSize = query.PageSize,
            Items = products
        };
    }
}
