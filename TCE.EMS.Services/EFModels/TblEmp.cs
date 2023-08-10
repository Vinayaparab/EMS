using System;
using System.Collections.Generic;

namespace TCE.EMS.Services.EFModels;

public partial class TblEmp
{
    public string EmpCode { get; set; } = null!;

    public string EmpName { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public bool? Status { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string LmodBy { get; set; } = null!;

    public DateTime LmodOn { get; set; }
}
