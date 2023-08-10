using System;
using System.Collections.Generic;

namespace TCE.EMS.Services.EFModels;

public partial class TblUserToken
{
    public int SrNo { get; set; }

    public string? EmpCode { get; set; }

    public string? Key { get; set; }

    public string? UserToken { get; set; }

    public DateTime? TokenUpdatedOn { get; set; }

    public DateTime? SessionUpdatedOn { get; set; }

    public int? TokenDuration { get; set; }

    public string? MobAppVerNo { get; set; }
}
