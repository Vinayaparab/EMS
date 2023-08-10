using System.ComponentModel.DataAnnotations;
using BZ.FW.Extensions;
using BZ.FW.Extensions.BulkUpload;
using TCE.EMS.Services.EFModels;
using Microsoft.AspNetCore.Http;
using BZ.FW.Extensions.Abstracts.Common;

namespace TCE.EMS.Services.Models
{
    public class CurrencySC
    {
        public string DocId { get; set; } = null!;

        [Required(ErrorMessage = "Currency Code cannot be left blank.")]
        [RegularExpression("^[A-Z]{3}$", ErrorMessage = "CurrencyCode must be a three-letter uppercase string.")]
        public string CurrCode { get; set; }

        [Required(ErrorMessage = "Currency Name cannot be left blank.")]
        public string CurrName { get; set; }

        public string IsActive { get; set; } = "";

        public decimal OrderNo { get; set; }

        public string IsAdvance { get; set; } = "";

        public string CreatedBy { get; set; } = "";

        public DateTime CreatedOn { get; set; }

        public string LmodBy { get; set; } = "";

        public DateTime LmodOn { get; set; }
    }
}