using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCE.EMS.Services.Models
{
    public class UserPropertiesSC
    {
        
        private Boolean _IsAdmin = false;
        private String _Roles = String.Empty;
        private String[] _RoleList = null;
         bool _IsUserSession = false;

        public bool IsUserSession
        {
            get { return _IsUserSession; }
            set { _IsUserSession = value; }
        }
        public Boolean IsAdmin
        {

            get { return _IsAdmin; }
            set { _IsAdmin = value; }
        }

        public String Roles
        {

            get { return _Roles; }
            set
            {
                _RoleList = _Roles.ToString().Split(new Char[] { ',' });
                _Roles = value;
            }
        }

        public String[] RoleList
        {
            get
            {
                return _RoleList;
            }
        }
    }
}