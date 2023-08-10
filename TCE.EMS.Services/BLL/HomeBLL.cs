using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCE.EMS.Services.DAL;
using TCE.EMS.Services.DBContext;
using TCE.EMS.Services.Models;

namespace TCE.EMS.Services.BLL
{
    
    public class HomeBLL
    {
         public DataSet GetMyTripDetails(String vEmpCode, String vTripID, String vType)
        {
            using (AppDBContext ctx = new AppDBContext())
            {
            HomeSC mHomeSC = null;
            HomeDAL mHomeDAL = null;
            DataSet mDSet = null;
            mHomeSC = new HomeSC();
            mHomeDAL = new HomeDAL();

            mDSet = mHomeDAL.GetMyTripDetails(vEmpCode, vTripID, vType,ctx);
            return mDSet;
            }
        }
    }
}