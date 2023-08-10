using System;
using System.Collections.Generic;

namespace TCE.EMS.Services.EFModels;

public partial class TblCurrency
{
    public string DocId { get; set; } = null!;

    public string CurrCode { get; set; } = null!;

    public string CurrName { get; set; } = null!;

    public string IsActive { get; set; } = null!;

    public decimal OrderNo { get; set; }

    public string IsAdvance { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string LmodBy { get; set; } = null!;

    public DateTime LmodOn { get; set; }
}
