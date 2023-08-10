using System;
using System.Collections.Generic;

namespace TCE.EMS.Services.EFModels;

public partial class CfgAppConfig
{
    public string SystemEmail { get; set; } = null!;

    public string SmtpIpaddress { get; set; } = null!;

    public string SmtpName { get; set; } = null!;

    public string SmtpSendUsing { get; set; } = null!;

    public int SmtpPort { get; set; }

    public string SmtpUser { get; set; } = null!;

    public string SmtpPassword { get; set; } = null!;

    public string SmtpAuthType { get; set; } = null!;

    public string SmtpSendMail { get; set; } = null!;

    public string IntranetUrl { get; set; } = null!;

    public string InternetUrl { get; set; } = null!;

    public string? MobIntranetUrl { get; set; }

    public string? MobAppCurrVerNo { get; set; }

    public string? MobAppCurrVerNoIOs { get; set; }

    public string? MobAppLink { get; set; }

    public string? MobAppLinkIOs { get; set; }
}
