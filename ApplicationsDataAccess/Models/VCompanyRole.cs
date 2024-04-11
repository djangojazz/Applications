using System;
using System.Collections.Generic;

namespace ApplicationsDataAccess.Models;

public partial class VCompanyRole
{
    public int CompanyId { get; set; }

    public string Company { get; set; } = null!;

    public string? City { get; set; }

    public string? Stateabbr { get; set; }

    public string StatusName { get; set; } = null!;

    public string RoleName { get; set; } = null!;

    public int? PayScaleStart { get; set; }

    public int PayScaleEnd { get; set; }

    public DateTime Applied { get; set; }

    public DateTime StatusChange { get; set; }

    public string? InterviewedWith { get; set; }

    public int? InterviewLevel { get; set; }

    public DateTime? InterviewTime { get; set; }

    public string? RoleDescription { get; set; }
}
