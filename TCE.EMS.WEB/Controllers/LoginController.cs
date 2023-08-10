using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TCE.EMS.WEB.Models;
using Microsoft.AspNetCore.Authorization;
using BZ.FW.WebUtility;
using TCE.EMS.Services.DBContext;
using BZ.FW.WebUtility.Security;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using BZ.FW.User;

namespace TCE.EMS.Web.Controllers;

[AllowAnonymous]
public class LoginController : BaseContoller
{

    private readonly IConfiguration _Configuration;
    public LoginController(IConfiguration ConfigurationObj)
    {
        this._Configuration = ConfigurationObj;
    }

    [AuthorizeRole("*")]
    public IActionResult Index()
    {
        if (SessionManager.IsSessionActive(this.HttpContext))
            return RedirectToAction("Index", "Home");
        else
            return View(new LoginUser());
    }

    [AuthorizeRole("*")]
    [HttpPost]
    public async Task<IActionResult> Authenticate(LoginUser LoginUserObj)
    {
        UserObj mUserObj = new UserObj();
        LoginReturnReceipt LoginReturnReceiptObj = new LoginReturnReceipt();
        var APIResult = "";

        try
        {
            if (!ModelState.IsValid)
            {
                LoginReturnReceiptObj.IsSuccess = "N";
                LoginReturnReceiptObj.Msg = "Please enter login and password to continue";
                return new JsonResult(LoginReturnReceiptObj);
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this._Configuration["AppSettings:WebAPIUrl"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsJsonAsync("Login/Authenticate", LoginUserObj);

                if (response.IsSuccessStatusCode)
                {
                    APIResult = response.Content.ReadAsStringAsync().Result;
                }
                LoginReturnReceiptObj = JsonConvert.DeserializeObject<LoginReturnReceipt>(APIResult);
                mUserObj = LoginReturnReceiptObj.UserObj[0];

                using (AppDBContext AppDBContextObj = new AppDBContext())
                {
                    AuthService AuthServiceObj = new AuthService(this._Configuration, this.HttpContext, AppDBContextObj);
                    await AuthServiceObj.SetSeesion(mUserObj);
                }
                return new JsonResult(LoginReturnReceiptObj);
            }
        }
        catch (Exception ex)
        {
            return RedirectToAction("Error", "Login");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [AuthorizeRole("*")]
    public async Task<IActionResult> Logout()
    {
        AuthService AuthServiceObj = new AuthService(this._Configuration, this.HttpContext, null);
        await AuthServiceObj.SignOut();

        return RedirectToAction("Index", "Login");
    }
}
