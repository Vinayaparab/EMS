using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCE.EMS.Services.Models
{
    public class DelegationList
    {
        private String _EmpCode = String.Empty;

        public String EmpCode
        {
            get
            {
                return _EmpCode;
            }
            set
            {
                _EmpCode = value;

            }
        }

        private String _EmpName = String.Empty;

        public String EmpName
        {
            get
            {
                return _EmpName;
            }
            set
            {
                _EmpName = value;

            }
        }

        private String _CanCreateRequest = String.Empty;

        public String CanCreateRequest
        {
            get
            {
                return _CanCreateRequest;
            }
            set
            {
                _CanCreateRequest = value;

            }
        }

        private String _CanApproveRequest = String.Empty;

        public String CanApproveRequest
        {
            get
            {
                return _CanApproveRequest;
            }
            set
            {
                _CanApproveRequest = value;

            }
        }
    }
}