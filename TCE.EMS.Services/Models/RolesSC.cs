using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCE.EMS.Services.Models
{
    public class RolesSC
    {
        public string RoleCode { get; set; } = null!;

        public string RoleDesc { get; set; } = null!;

        public string CreatedBy { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public string LmodBy { get; set; } = null!;

        public DateTime LmodOn { get; set; }
    }
}