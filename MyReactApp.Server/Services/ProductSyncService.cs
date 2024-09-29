using Microsoft.EntityFrameworkCore;
using MyReactApp.Server.Data;
using MyReactApp.Server.Models;

namespace MyReactApp.Server.Services;

public class ProductSyncService
{
    private readonly ShopDbContext _dbContext;
    private readonly ProductFetchService _fetchService;
    private readonly ProductMappingService _mappingService;

    public ProductSyncService(ShopDbContext dbContext, ProductFetchService fetchService, ProductMappingService mappingService)
    {
        _dbContext = dbContext;
        _fetchService = fetchService;
        _mappingService = mappingService;
    }

    public async Task SyncProducts()
    {
        // Clear existing data from the related tables
        await ClearDataFromTables();

        // Fetch products (page and size)
        var products = await _fetchService.FetchProducts(1, 50);

        foreach (var product in products)
        {
            var productId = product.ProductId;

            //// Handle brand mapping
            await SyncBrandAsync(product.Brand);

            //// Handle product mapping
            await SyncProductAsync(productId, product);

            //// Handle price mapping
            await SyncPriceAsync(productId, product);

            //// Handle image mapping
            await SyncImageAsync(productId, product.Images);

            //// Handle cateogry mapping
            await SyncCategoryAsync(productId, product.Categories);

            //// Handle tag mapping
            await SyncProductTagAsync(productId, product.Tags);
        }
    }

    private async Task ClearDataFromTables()
    {
        await _dbContext.ProductImages.ExecuteDeleteAsync();
        await _dbContext.Images.ExecuteDeleteAsync();
        await _dbContext.ProductCategories.ExecuteDeleteAsync();
        await _dbContext.Categories.ExecuteDeleteAsync();
        await _dbContext.ProductTags.ExecuteDeleteAsync();
        await _dbContext.Tags.ExecuteDeleteAsync();
        await _dbContext.Prices.ExecuteDeleteAsync();
        await _dbContext.Products.ExecuteDeleteAsync();
        await _dbContext.Brands.ExecuteDeleteAsync();

        // Save changes
        await _dbContext.SaveChangesAsync();
    }

    private async Task SyncBrandAsync(OBrand brand)
    {
        if (brand != null)
        {
            var brandEntity = _mappingService.MapToBrandEntity(brand);

            // Check if brand exists in the brand database
            var existingBrand = await _dbContext.Brands
                .FirstOrDefaultAsync(b => b.Name == brandEntity.Name);

            if (existingBrand == null)
            {
                _dbContext.Brands.Add(brandEntity); // Add new brand if it doesn't exist
                await _dbContext.SaveChangesAsync(); // Save to DB
            }
        }
    }

    private async Task SyncProductAsync(long productId, OProduct product)
    {

        var firstBrand = await _dbContext.Brands.FirstOrDefaultAsync();
        var productEntity = _mappingService.MapToProductEntity(product, firstBrand);

        var existingProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);
        if (existingProduct == null)
        {
            // Add product to DB
            _dbContext.Products.Add(productEntity);
            await _dbContext.SaveChangesAsync(); // Save to DB
        }
    }

    private async Task SyncPriceAsync(long productId, OProduct product)
    {
        var priceEntity = _mappingService.MapToPriceEntity(product, productId);

        // Check if productId exists in the price database
        var existingProductPrice = await _dbContext.Prices
            .FirstOrDefaultAsync(p => p.ProductId == productId);

        if (existingProductPrice == null)
        {
            _dbContext.Prices.Add(priceEntity); // Add new price if it doesn't exist
            await _dbContext.SaveChangesAsync(); // Save to DB
        }
    }

    private async Task SyncImageAsync(long productId, List<OImage> images)
    {
        var imageEntities = _mappingService.MapToImageEntities(images);

        foreach (var imageEntity in imageEntities)
        {
            // Check if the image already exists in the image database
            var existingImage = await _dbContext.Images
                .FirstOrDefaultAsync(i => i.Name == imageEntity.Name);

            if (existingImage == null)
            {
                // Image doesn't exist, so add it
                _dbContext.Images.Add(imageEntity);

                // Save changes to generate the ImageId
                await _dbContext.SaveChangesAsync();

                // Add the productImage relationship
                _dbContext.ProductImages.Add(new ProductImage
                {
                    ProductId = productId,
                    ImageId = imageEntity.Id,
                });
                await _dbContext.SaveChangesAsync(); // Save to DB
            }
        }
    }

    private async Task SyncCategoryAsync(long productId, List<OCategory> categories)
    {
        var categoryEntities = _mappingService.MapToCategoryEntities(categories);

        foreach (var categoryEntity in categoryEntities)
        {
            // Check if the category already exists in the category database
            var existingCategory = await _dbContext.Categories
                .FirstOrDefaultAsync(i => i.Name == categoryEntity.Name);

            if (existingCategory == null)
            {
                // Category doesn't exist, so add it
                _dbContext.Categories.Add(categoryEntity);

                // Save changes to generate the categoryId
                await _dbContext.SaveChangesAsync();

                // Add the productCategory relationship
                _dbContext.ProductCategories.Add(new ProductCategory
                {
                    ProductId = productId,
                    CategoryId = categoryEntity.Id,
                });
                await _dbContext.SaveChangesAsync(); // Save to DB
            }
        }
    }

    private async Task<Collection> SyncCollectionAsync(long collectionId, string collectionName)
    {
        // Check if collection exists in the database
        var existingCollection = await _dbContext.Collections
            .FirstOrDefaultAsync(c => c.Id == collectionId);

        // If collection does not exist, create a new one
        if (existingCollection == null)
        {
            var newCollection = ProductMappingService.MapToCollection(collectionId, collectionName);
            _dbContext.Collections.Add(newCollection);
            await _dbContext.SaveChangesAsync();

            return newCollection;
        }

        return existingCollection;
    }

    private async Task<Tag> SyncTagAsync(OTag oTag)
    {
        // First, sync the collection
        var collection = await SyncCollectionAsync(oTag.CollectionId, oTag.CollectionName);

        // Check if the tag exists in the database
        var existingTag = await _dbContext.Tags
            .FirstOrDefaultAsync(t => t.Id == oTag.Id);

        if (existingTag == null)
        {
            // Map and create the new tag if it doesn't exist
            var newTag = ProductMappingService.MapToTagEntity(oTag, collection);
            _dbContext.Tags.Add(newTag);
            await _dbContext.SaveChangesAsync();

            return newTag;
        }

        return existingTag;
    }

    private async Task SyncProductTagAsync(long productId, List<OTag> tags)
    {
        foreach (var tag in tags)
        {
            // Sync the tag first
            var _tag = await SyncTagAsync(tag);

            // Check if the ProductTag relationship already exists
            var existingProductTag = await _dbContext.ProductTags
                .FirstOrDefaultAsync(pt => pt.ProductId == productId && pt.TagId == _tag.Id);

            if (existingProductTag == null)
            {
                // Create the ProductTag relationship if it doesn't exist
                var productTag = new ProductTag
                {
                    ProductId = productId,
                    TagId = _tag.Id,
                    Tag = _tag
                };

                _dbContext.ProductTags.Add(productTag);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
