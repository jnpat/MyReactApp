namespace MyReactApp.Server.Data;

public class OProduct
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string ThumbnailImage { get; set; }
    public OPrice Price { get; set; }
    public OPrice OriginalPrice { get; set; }
    public OBrand Brand { get; set; }
    public int Sold { get; set; }
    public bool AllowMultipleConfigs { get; set; }
    public string Url { get; set; }
    public DateTime Created { get; set; }
    public double? ReviewScore { get; set; }
    public int ReviewCount { get; set; }
    public bool Has3DAssets { get; set; }
    public string? Layout { get; set; }
    public string? Location { get; set; }
    public OPrice FullPriceBeforeOverallDiscount { get; set; }
    public OPrice PossibleDiscountPrice { get; set; }
    public List<OCategory> Categories { get; set; }
    public List<OTag> Tags { get; set; }
    public List<OImage> Images { get; set; }
    public Dictionary<int, List<OImage>> ImageTaxonomyTags { get; set; }
}
