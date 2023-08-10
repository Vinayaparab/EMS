using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BZ.FW.Common;
using TCE.EMS.Services;
using TCE.EMS.Services.DAL;
using TCE.EMS.Services.BLL;
using TCE.EMS.Services.Models;
using System.Data;
using BZ.FW.User;
using System.Data.Entity;
using TCE.EMS.Services.DBContext;
using BZ.FW.WebUtility.Security;
using JWTAuth.Providers.JWTAuthProvider;
using BZ.FW.WebAPIUtility;
using BZ.FW.WebAPIUtility.Utilities;

namespace TCE.EMS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _Configuration;
        private JWTAuth.Providers.JWTAuthProvider.AuthService _authService;
        public LoginController(IConfiguration ConfigurationObj)
        {
            this._Configuration = ConfigurationObj;
        }
        DbContext _DbContext { get; set; }
        public BZ.FW.User.UserObj? UserObj
        {
            get
            {
                return SessionManager.GetUserObj(this.HttpContext);
            }
        }

        #region Authenticate 
        [AuthorizeRole("*")]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate(LoginUser LoginUserObj)
        {
            UserObj mUserObj = new UserObj();
            LoginReturnReceipt LoginReturnReceiptObj = new LoginReturnReceipt();
            using (AppDBContext AppDBContextObj = new AppDBContext())
            {
                AuthenticateTokenService AuthServiceObj = new AuthenticateTokenService(this._Configuration, this.HttpContext, AppDBContextObj);

                LoginReturnReceiptObj = await AuthServiceObj.SignIn(LoginUserObj);
            }
            return new JsonResult(LoginReturnReceiptObj);
        }
        #endregion Authenticate
    }
}