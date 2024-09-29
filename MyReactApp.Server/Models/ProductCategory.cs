using System;
using System.Collections.Generic;

namespace MyReactApp.Server.Models;

public partial class ProductCategory
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public long CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
