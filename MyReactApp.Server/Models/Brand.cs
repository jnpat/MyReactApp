using System;
using System.Collections.Generic;

namespace MyReactApp.Server.Models;

public partial class Brand
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? UserIdentifier { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
