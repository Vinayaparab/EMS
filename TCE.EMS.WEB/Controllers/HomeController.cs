using System.Diagnostics;
using BZ.FW.WebUtility;
using Microsoft.AspNetCore.Mvc;
using TCE.EMS.Services.BLL;
using TCE.EMS.WEB.Models;
using BZ.FW.WebUtility.Security;
using System.Data;
using TCE.EMS.Services.Models;
using Newtonsoft.Json;

namespace TCE.EMS.Web.Controllers;

public class HomeController : BaseContoller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [AuthorizeRole("*")]
    public IActionResult Index()
    {
        if (this.UserObj.Roles.HasRole("[Admin]"))
        {
            ViewBag.IsAdmin = "Y";
        }
        else
        {
            ViewBag.IsAdmin = "N";
        }

        // GetTopSurveyList();

        return View();
    }

    [AuthorizeRole("*")]
    public IActionResult Privacy()
    {
        return View();
    }

    [AuthorizeRole("*")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }

    // [HttpPost]
    // public dynamic GetSurveyStatusRpt(string mSurveyId, string mRptType)
    // {
    //     try
    //     {
    //         ReportsService mReportsService = new ReportsService(this.UserObj);
    //         var mDSet = mReportsService.SurveyStatusRpt(Convert.ToInt64(mSurveyId), mRptType);
    //         return mDSet;
    //     }
    //     catch (Exception ex)
    //     {
    //         throw ex;
    //     }
    // }

    // public void GetTopSurveyList()
    // {
    //     ReportsService mReportsService = new ReportsService(this.UserObj);
    //     var mDSet = mReportsService.TopSurveyList();
    //     ViewBag.TopSurveyList = mDSet;
    // }
}
