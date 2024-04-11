using System;
using System.Collections.Generic;

namespace ApplicationsDataAccess.Models;

public partial class Interview
{
    public int InterviewId { get; set; }

    public string InterviewedWith { get; set; } = null!;

    public int InterviewLevel { get; set; }

    public int CompanyId { get; set; }

    public DateTime Created { get; set; }

    public virtual Company Company { get; set; } = null!;
}
