using System;
using System.Collections.Generic;

namespace MyReactApp.Server.Models;

public partial class Tag
{
    public long Id { get; set; }

    public long ParentId { get; set; }

    public string Name { get; set; } = null!;

    public string ParentName { get; set; } = null!;

    public string? UserIdentifier { get; set; }

    public long CollectionId { get; set; }

    public string? ThumbnailImage { get; set; }

    public virtual Collection Collection { get; set; } = null!;

    public virtual ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
}
