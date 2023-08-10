using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BZ.FW.WebUtility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TCE.EMS.Services.Models;
using BZ.FW.WebUtility.Utilities;
using BZ.FW.Common;

namespace TCE.EMS.WEB.Controllers
{
    // [Route("[controller]")]
    public class CurrencyController : BaseContoller
    {
        private readonly IConfiguration _Configuration;
        public CurrencyController(IConfiguration ConfigurationObj)
        {
            this._Configuration = ConfigurationObj;

        }
        public IActionResult DataView()
        {
            try
            {
                return View("CurrencyView");
            }
            catch (Exception ex)
            {
                return ErrorUtility.GetErrorPage(this, ex);
            }
        }

        public IActionResult New()
        {
            try
            {
                CurrencySC CrnObj = new CurrencySC();

                return View("CurrencyForm", CrnObj);
            }
            catch (Exception ex)
            {
                return ErrorUtility.GetErrorPage(this, ex);
            }

        }

        [HttpPost]
        public async Task<IActionResult> GetViewData(string IsStatus)
        {
            try
            {
                DataGridHelper mDataGridHelperObj = new DataGridHelper();

                DataGridFilter mDataGridFilterObj = new DataGridFilter();
                List<DataGridFilter> vParam = new List<DataGridFilter>();

                WebApiParam mWebAPIParamObj = new WebApiParam();
                mDataGridFilterObj.Key = "IsStatus";
                mDataGridFilterObj.Value = "";
                vParam.Add(mDataGridFilterObj);

            return await mDataGridHelperObj.GetDataList(this, this._Configuration, UserObj, "Currency", "GetList",vParam);
            }
            catch (Exception ex)
            {
                throw ErrorUtility.GetErrorForGrid(this, ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ReturnReceipt> Save(CurrencySC CurrencySCObj)
        {
            ReturnReceipt mReturnReceiptObj = new ReturnReceipt();
            try
            {
                WebApiHelper mWebApiHelperobj = new WebApiHelper(this._Configuration, UserObj);
                CurrencySCObj.DocId = "";
                return mReturnReceiptObj = await mWebApiHelperobj.Post<ReturnReceipt>("Currency", "Update", CurrencySCObj);
            }
            catch (Exception ex)
            {
                log4net.GlobalContext.Properties["UserId"] = UserObj.Properties.UserID;
                return ErrorUtility.GetErrorReceipt(this, ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            try
            {
                CurrencySC mCrn = null;
                List<WebApiParam> vParam = new List<WebApiParam>();

                WebApiParam mWebAPIParamObj = new WebApiParam();
                mWebAPIParamObj.Key = "ID";
                mWebAPIParamObj.Value = id;
                vParam.Add(mWebAPIParamObj);
                WebApiHelper mWebApiHelperobj = new WebApiHelper(this._Configuration, UserObj);
                mCrn = await mWebApiHelperobj.Get<CurrencySC>("Currency", "Get", vParam);
                return View("CurrencyForm", mCrn);
            }
            catch (Exception ex)
            {
                log4net.GlobalContext.Properties["UserId"] = UserObj.Properties.UserID;
                return ErrorUtility.GetErrorPage(this, ex);
            }
        }




    }
}