using MyReactApp.Server.Data;
using MyReactApp.Server.Models;

namespace MyReactApp.Server.Services;

public class ProductMappingService
{
    public Brand MapToBrandEntity(OBrand brand)
    {
        return new Brand
        {
            Name = brand.Name,
            UserIdentifier = brand.UserIdentifier,
        };
    }

    public Price MapToPriceEntity(OProduct product, long productId)
    {
        return new Price
        {
            ProductId = productId,
            Currency = product.Price.Currency,
            Amount = product.Price.Amount,
            OgCurrency = product.OriginalPrice.Currency,
            OgAmount = product.OriginalPrice.Amount,
            FpCurrency = product.FullPriceBeforeOverallDiscount.Currency,
            FpAmount = product.FullPriceBeforeOverallDiscount.Amount,
            DpCurrency = product.PossibleDiscountPrice.Currency,
            DpAmount = product.PossibleDiscountPrice.Amount,
        };
    }

    public Category MapToCategoryEntity(OCategory category)
    {
        return new Category
        {
            Id = category.Id,
            ParentId = category.ParentId ?? 0,
            Name = category.Name,
            Title = category.Title,
        };
    }

    public List<Category> MapToCategoryEntities(List<OCategory> oCategories)
    {
        return oCategories.Select(MapToCategoryEntity).ToList();
    }

    public Image MapToImageEntity(OImage image)
    {
        return new Image
        {
            Name = image.Name,
            Description = image.Description,
            Alt = image.Alt,
            Original = image.Original,
            Large = image.Large,
            MediumLarge = image.MediumLarge,
            Medium = image.Medium,
            MediumSmall = image.MediumSmall,
            Small = image.Small,
            Thumbnail = image.Thumbnail,
            SmallThumbnail = image.SmallThumbnail,
        };
    }

    public List<Image> MapToImageEntities(List<OImage> oImage)
    {
        return oImage.Select(MapToImageEntity).ToList();
    }

    public Product MapToProductEntity(OProduct product, Brand brand)
    {
        return new Product
        {
            Id = product.ProductId,
            Name = product.Name,
            Title = product.Title,
            ThumbnailImage = product.ThumbnailImage ?? null,
            Sold = product.Sold,
            AllowMultipleConfig = product.AllowMultipleConfigs,
            Url = product.Url,
            CreatedDate = product.Created,
            ReviewScore = product.ReviewScore.HasValue ? (decimal)product.ReviewScore.Value : 0.00m,
            ReviewCount = product.ReviewCount,
            Has3dAssets = product.Has3DAssets,
            Layout = product.Layout,
            Location = product.Location,
            Brand = brand,
            Prices = new List<Price>()
        };
    }

    public static Collection MapToCollection(long collectionId, string collectionName)
    {
        return new Collection
        {
            Id = collectionId,
            Name = collectionName,
        };
    }

    public static Tag MapToTagEntity(OTag tag, Collection collection)
    {
        return new Tag
        {
            Id = tag.Id,
            ParentId = 0,
            Name = tag.Name,
            ParentName = tag.ParentName,
            UserIdentifier = tag.UserIdentifier,
            ThumbnailImage = tag.ThumbnailImage,
            CollectionId = tag.CollectionId,
            Collection = collection,
        };
    }
}
