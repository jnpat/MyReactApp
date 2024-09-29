using System;
using System.Collections.Generic;

namespace MyReactApp.Server.Models;

public partial class Category
{
    public long Id { get; set; }

    public long ParentId { get; set; }

    public string Name { get; set; } = null!;

    public string Title { get; set; } = null!;

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
}
