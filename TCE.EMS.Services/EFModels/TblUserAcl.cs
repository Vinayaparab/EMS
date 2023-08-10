using System;
using System.Collections.Generic;

namespace TCE.EMS.Services.EFModels;

public partial class TblUserAcl
{
    public int UserAclid { get; set; }

    public string Aclcode { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string RoleCode { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime ModifiedOn { get; set; }
}
