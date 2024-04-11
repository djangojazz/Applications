using System;
using System.Collections.Generic;

namespace ApplicationsDataAccess.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
}
