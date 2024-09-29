using System;
using System.Collections.Generic;

namespace MyReactApp.Server.Models;

public partial class Product
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? ThumbnailImage { get; set; }

    public long BrandId { get; set; }

    public int Sold { get; set; }

    public bool AllowMultipleConfig { get; set; }

    public string Url { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public decimal? ReviewScore { get; set; }

    public int ReviewCount { get; set; }

    public bool Has3dAssets { get; set; }

    public string? Layout { get; set; }

    public string? Location { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
}
