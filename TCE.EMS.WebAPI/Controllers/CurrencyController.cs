using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BZ.FW.Common;
using BZ.FW.DataGrid;
using BZ.FW.WebAPIUtility;
using BZ.FW.WebAPIUtility.Utilities;
using JWTAuth.Providers.JWTAuthProvider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TCE.EMS.Services.BLL;
using TCE.EMS.Services.DBContext;
using TCE.EMS.Services.Models;

namespace TCE.EMS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : BZ.FW.WebAPIUtility.BaseApiContoller<AppDBContext>
    {
       public CurrencyController(IConfiguration ConfigurationObj) : base(ConfigurationObj)
        {
        }



        [TokenAuthenticate]
        [HttpGet("Get")]
        public DataReceipt<CurrencySC> Get(string Id)
        {
            try
            {
                CurrencySC mCurrencySCObj = new CurrencySC();
                CurrencyService mCntService = null;

                mCntService = new CurrencyService(this.UserObj);
                mCurrencySCObj = mCntService.Get(Id);

                DataReceipt<CurrencySC> mDataReceipt = new DataReceipt<CurrencySC>();
                mDataReceipt.IsSuccess = true;
                mDataReceipt.DataObj = mCurrencySCObj;

                return mDataReceipt;

            }
            catch (Exception ex)
            {
                return ErrorUtility.GetErrorReceiptForGet<CurrencySC>(this, ex);
            }
        }


        [TokenAuthenticate]
        [HttpPost("GetList")]
        public async Task<DataList> GetList(DataGridParams mGridParams)
        {
            try
            {
                return (new DataServiceHelper(this._Configuration, this.HttpContext, this.UserObj)).GetList<CurrencyService>(mGridParams);
            }
            catch (Exception ex)
            {
                return ErrorUtility.GetErrorReceiptForList(this, ex);
            }
        }

        [TokenAuthenticate]
        [HttpPost("Update")]
        public ReturnReceipt Update([FromBody] CurrencySC CurrencySCObj)
        {
            try
            {
                ReturnReceipt mReturnReceiptObj = new ReturnReceipt();
                CurrencyService mCurrencyBLL = null;

                mCurrencyBLL = new CurrencyService(this.UserObj);
                mReturnReceiptObj = mCurrencyBLL.Save(CurrencySCObj);

                return mReturnReceiptObj;
            }
            catch (Exception ex)
            {
                return ErrorUtility.GetErrorReceipt(this, ex);
            }
        }
    }
}