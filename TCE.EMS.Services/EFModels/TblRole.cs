using System;
using System.Collections.Generic;

namespace TCE.EMS.Services.EFModels;

public partial class TblRole
{
    public string RoleCode { get; set; } = null!;

    public string RoleDesc { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string LmodBy { get; set; } = null!;

    public DateTime LmodOn { get; set; }
}
