using System;
using System.Collections.Generic;

namespace ApplicationsDataAccess.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public int CompanyId { get; set; }

    public string RoleName { get; set; } = null!;

    public int? PayScaleStart { get; set; }

    public int PayScaleEnd { get; set; }

    public byte[]? RoleDescription { get; set; }

    public virtual Company Company { get; set; } = null!;
}
