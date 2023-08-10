using TCE.EMS.Services.Models;
using TCE.EMS.Services.DAL;
using BZ.FW.DataGrid;
using BZ.FW.Extensions.Validators;
using BZ.FW.Common;
using BZ.FW.Extensions.BulkUpload;
using System.Data;
using TCE.EMS.Services.DBContext;
using TCE.EMS.Services.EFModels;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;


namespace TCE.EMS.Services.BLL;

public class CurrencyService
{
    BZ.FW.User.UserObj? UserObj { get; set; }

    public CurrencyService()
    {
    }

    public CurrencyService(BZ.FW.User.UserObj? vUserObj)
    {
        this.SetUserObj(vUserObj);
    }

    public void SetUserObj(BZ.FW.User.UserObj? vUserObj)
    {
        this.UserObj = vUserObj;
    }

    public dynamic GetList(DataGridParams vGridParams, ref int totalrecords)
    {
        CurrencyDAL mCrnDAL = new CurrencyDAL();
        var data = mCrnDAL.GetList(vGridParams, ref totalrecords);
        return data;
    }

    public ReturnReceipt Save(CurrencySC CrnObj)
    {
        ReturnReceipt mReturnReceipt = new ReturnReceipt();

        mReturnReceipt = this.Validate(CrnObj);
        if (mReturnReceipt.IsSuccess == "N")
            return mReturnReceipt;
        CurrencyDAL mCrnDAL = new CurrencyDAL();
        try
        {
            mCrnDAL.Save(CrnObj);
        }
        catch (Exception ex)
        {
            string errorMessage = ex.Message;
            string innerErrorMessage = ex.InnerException?.Message;

        }
        mReturnReceipt.IsSuccess = "Y";
        return mReturnReceipt;
    }

    public ReturnReceipt Validate(CurrencySC vCrn)
    {
        ReturnReceipt mReturnReceipt = new ReturnReceipt();
        mReturnReceipt.ErrorList = DataAnnotationsValidator.ValidateModel(vCrn);

        if (mReturnReceipt.ErrorList.Count > 0)
        {
            mReturnReceipt.IsSuccess = "N";
            return mReturnReceipt;
        }

        CurrencyDAL EmpDALObj = new CurrencyDAL();


        if (mReturnReceipt.ErrorList.Count > 0)
        {
            mReturnReceipt.IsSuccess = "N";
            return mReturnReceipt;
        }
        mReturnReceipt.IsSuccess = "Y";
        return mReturnReceipt;
    }

    public CurrencySC Get(string vId)
    {
        CurrencySC mCrnObj = new CurrencySC();
        CurrencyDAL mCrnDAL = new CurrencyDAL();
        mCrnObj = mCrnDAL.Get(vId);
        return mCrnObj;
    }

}