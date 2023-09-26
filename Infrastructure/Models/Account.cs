using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Account
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public string Name { get; set; } = null!;

    public string Identifier { get; set; } = null!;

    public virtual ICollection<Deep> Deeps { get; set; } = new List<Deep>();
}
