using System;
using System.Collections.Generic;

namespace MyReactApp.Server.Models;

public partial class Image
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Alt { get; set; } = null!;

    public string Original { get; set; } = null!;

    public string Large { get; set; } = null!;

    public string MediumLarge { get; set; } = null!;

    public string Medium { get; set; } = null!;

    public string MediumSmall { get; set; } = null!;

    public string Small { get; set; } = null!;

    public string Thumbnail { get; set; } = null!;

    public string SmallThumbnail { get; set; } = null!;

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
}
