
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using TCE.EMS.Services.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using BZ.FW.Helper;
using TCE.EMS.Services.DBContext;

namespace TCE.EMS.Services.DAL
{
    public class HomeDAL
    {
        // private Database currentDatabase;

        // public HomeDAL()
        // {
        //     currentDatabase = DatabaseFactory.CreateDatabase(StoredProcedure.DBName);
        // }
        public DataSet GetMyTripDetails(String vEmpCode, String vTripID, String vType,AppDBContext ctx)
        {
            DbCommand mDbCommand = null;
            String mStoredProcedure = String.Empty;
            DataSet mDSet = null;
            HomeSC mHomeSCObj = null;

            mStoredProcedure = StoredProcedure.spr_GetMyTripDetails;
            DBQParamCollectionHelper mParamList = new DBQParamCollectionHelper();

             mParamList.Add("@vEmpCode", DbType.String, vEmpCode);
             mParamList.Add("@vTripID", DbType.String, vTripID);
             mParamList.Add("@vType", DbType.String, vType);
             mDSet = DBHelper.ExecuteDataset(ctx, mStoredProcedure, mParamList);

            if (mDSet.Tables[0].Rows.Count > 0)
            {
                mHomeSCObj = new HomeSC();
                mHomeSCObj.TripID = mDSet.Tables[0].Rows[0]["TripID"].ToString();
                mHomeSCObj.TripType = mDSet.Tables[0].Rows[0]["TripType"].ToString();
                mHomeSCObj.JobCode = mDSet.Tables[0].Rows[0]["JobCode"].ToString();
                mHomeSCObj.JobTitle = mDSet.Tables[0].Rows[0]["JobTitle"].ToString();
                mHomeSCObj.FromDT = mDSet.Tables[0].Rows[0]["FromDT"].ToString();
                mHomeSCObj.ToDT = mDSet.Tables[0].Rows[0]["ToDT"].ToString();
                mHomeSCObj.TotDays = mDSet.Tables[0].Rows[0]["TotDays"].ToString();
                //mHomeSCObj.WF_Status = mDSet.Tables[0].Rows[0]["WF_StatusDesc"].ToString();

                //mHomeSCObj.WF_Status = mDSet.Tables[0].Rows[0]["WF_StatusDesc"].ToString();

            }
            return mDSet;
        }
        

    }
}