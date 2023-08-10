using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCE.EMS.Services.Models
{
    public class UserRoleSC
    {
        private String _RoleID = String.Empty;
        private String _RoleDesc = String.Empty;
        public String RoleID
        {
            get { return _RoleID; }
            set { _RoleID = value; }
        }
        public String RoleDesc
        {
            get { return _RoleDesc; }
            set { _RoleDesc = value; }
        }
    }
}