using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCE.EMS.Services.Models
{
    public class HomeSC
    {

        private String _TripID = String.Empty;
        private String _TripType = String.Empty;
        private String _JobCode = String.Empty;
        private String _JobTitle = String.Empty;
        private String _FromDT = String.Empty;
        private String _ToDT = String.Empty;
        private String _TotDays = String.Empty;

        public String TotDays
        {
            get { return _TotDays; }
            set { _TotDays = value; }
        }

        private String _WF_Status = String.Empty;

        public String WF_Status
        {
            get { return _WF_Status; }
            set { _WF_Status = value; }
        }

        public String TripID
        {
            get { return _TripID; }
            set { _TripID = value; }
        }

        public String TripType
        {
            get { return _TripType; }
            set { _TripType = value; }
        }

        public String JobCode
        {
            get { return _JobCode; }
            set { _JobCode = value; }
        }

        public String JobTitle
        {
            get { return _JobTitle; }
            set { _JobTitle = value; }
        }

        public String FromDT
        {
            get { return _FromDT; }
            set { _FromDT = value; }
        }
        public String ToDT
        {
            get { return _ToDT; }
            set { _ToDT = value; }
        }
    }
}