using System;
using System.Collections.Generic;

namespace MyReactApp.Server.Models;

public partial class Collection
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
