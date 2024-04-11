using System;
using System.Collections.Generic;

namespace ApplicationsDataAccess.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public string Company1 { get; set; } = null!;

    public string? City { get; set; }

    public string? StateAbbr { get; set; }

    public int StatusId { get; set; }

    public DateTime Applied { get; set; }

    public DateTime StatusChange { get; set; }

    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public virtual Status Status { get; set; } = null!;
}
