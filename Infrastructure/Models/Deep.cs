using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Deep
{
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public Guid AccountGuid { get; set; }

    public DateTime Date { get; set; }

    public string? Text { get; set; }

    public virtual Account? Account { get; set; }
}
