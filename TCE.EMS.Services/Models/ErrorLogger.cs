using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace TCE.EMS.Services.Models
{
    public class ErrorLogger
    {
        public static void Log(string Module, String vMsg)
        {
            String vIsLogEnabled = String.Empty;
            vIsLogEnabled = ConfigurationManager.AppSettings["IsLogEnabled"].ToString();

            if (vIsLogEnabled == "Y")
            {
                //String mLogPath = string.Empty;

                //mLogPath= ConfigurationManager.AppSettings["ErrorLogPath"].ToString();

                //mLogPath = String.IsNullOrEmpty(ConfigurationManager.AppSettings["ErrorLogPath"]) ? "" : ConfigurationManager.AppSettings["ErrorLogPath" + Module].ToString();

                string mErrorLogPath = string.Empty;

                //mErrorLogPath = HttpContext.Current.Server.MapPath(mLogPath);

                mErrorLogPath = AppDomain.CurrentDomain.BaseDirectory;

                mErrorLogPath = mErrorLogPath + "Log\\" + Module + "\\Logger\\";
                if (!Directory.Exists(mErrorLogPath))
                {
                    Directory.CreateDirectory(mErrorLogPath);
                }
                mErrorLogPath = mErrorLogPath + "Logger_" + DateTime.Now.ToString("dd-MMM-yyyy") + ".log";

                File.AppendAllText(mErrorLogPath, Environment.NewLine);
                File.AppendAllText(mErrorLogPath, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "::" + vMsg);
            }
        }
    }
}