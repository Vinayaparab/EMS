using System;
using TCE.EMS.Services;
using TCE.EMS.Services.Models;
using TCE.EMS.Services.DBContext;
using TCE.EMS.Services.EFModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using BZ.FW.Extensions;
using BZ.FW.DataGrid;


namespace TCE.EMS.Services.DAL
{
    public class CurrencyDAL
    {

    
    public dynamic GetList(DataGridParams vGridParams, ref int totalrecords)
    {
        using (AppDBContext _context = new AppDBContext())
        {
            // Getting all Candidate data                    
            var query = from TblCurrency in _context.TblCurrencies
                        orderby TblCurrency.CurrCode
                        select new
                        {
                            DocId = TblCurrency.DocId,
                            CurrCode = TblCurrency.CurrCode,
                            CurrName = TblCurrency.CurrName,
                            IsActive = TblCurrency.IsActive,
                            OrderNo = TblCurrency.OrderNo,
                            IsAdvance = TblCurrency.IsAdvance,
                            CreatedBy = TblCurrency.CreatedBy,
                            CreatedOn = TblCurrency.CreatedOn,
                            LmodBy = TblCurrency.LmodBy,
                            LmodOn = TblCurrency.LmodOn
                        };
            //Filter
            if (!string.IsNullOrEmpty(vGridParams.searchValue))
                query = query.Where(m => m.CurrCode == vGridParams.searchValue || m.CurrCode.Contains(vGridParams.searchValue));

            // //Sorting
            if (!(string.IsNullOrEmpty(vGridParams.sortColumn) && string.IsNullOrEmpty(vGridParams.sortColumnDir)))
            {
                query = query.OrderBy(vGridParams.sortColumn + " " + vGridParams.sortColumnDir);
            }

            //Total Records Count
            totalrecords = query.Count();

            //Pagination
            var data = query.Skip(vGridParams.skip).Take(vGridParams.pageSize).ToList();

            //Returning Json Data    
            return data;
        }
    }

    public void Save(CurrencySC CndObj)
    {
        using (AppDBContext AppDBContextObj = new AppDBContext())
        {

            TblCurrency TblCurObj = new TblCurrency();

            if (CndObj.DocId == null || CndObj.DocId == "")
            {
                Guid vDocid = Guid.NewGuid();
                CndObj.DocId = vDocid.ToString();

                TblCurObj.CopyPropertiesFrom(CndObj);
                AppDBContextObj.TblCurrencies.Add(TblCurObj);

            }
            else
            {
                TblCurObj = AppDBContextObj.TblCurrencies.First(x => x.DocId == CndObj.DocId);
                TblCurObj.CopyPropertiesFrom(CndObj);
                AppDBContextObj.Entry(TblCurObj).State = EntityState.Modified;
            }
            AppDBContextObj.SaveChanges();
        }
    }

    public CurrencySC Get(string vId)
    {
        CurrencySC? mCurrencyObj = null;
        try{
        using (AppDBContext mAppDBContext = new AppDBContext())
        {
            var Cmn = (from c in mAppDBContext.TblCurrencies select c).
                        Where(x => x.DocId == vId).FirstOrDefault<TblCurrency>();

                  

            if (Cmn != null)
            {
                mCurrencyObj = new CurrencySC();
                mCurrencyObj.CopyPropertiesFrom(Cmn);
            }
            
        }
        }
        catch(Exception ex)
        {
            throw ex;
        }
        return mCurrencyObj;
    }

}
}