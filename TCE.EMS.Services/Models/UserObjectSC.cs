using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCE.EMS.Services.Models;

namespace TCE.EMS.Services.Models
{
    [Serializable()]
    public class UserObjectSC : ICloneable
    {

        #region " Global Variables "



        private String _RoleID = String.Empty;
        private String _Roles = String.Empty;
        private String _CreatedBy = String.Empty;
        private String _CreatedOn = String.Empty;
        private String _LModBy = String.Empty;
        private String _LModOn = String.Empty;

        private String _EmpCode = String.Empty;

        private String _HasDelegationRights = String.Empty;

        private Int64 _EmpID = 0;
        private String _EmpName = String.Empty;
        private String _EmailAdd = String.Empty;
        private UserPropertiesSC _UserProperties = null;
        private String _RoleCode = String.Empty;
        private String _NotiText = String.Empty;
        private String _NotiHeader = String.Empty;
        private String _ShowNotification = String.Empty;
        private String _RoleDesc = String.Empty;
        private String _EmpSAPVendCode = String.Empty;
        

       public List<UserRoleSC> UserRoles = new List<UserRoleSC>();
       public List<DelegationList> DelegationList = new List<DelegationList>();

    //     public List<AdminRoleSC> AdminRoleList = new List<AdminRoleSC>();
        private String _Department = String.Empty;

        private string _AuthToken = string.Empty;

        private string _AuthTokenDuration = string.Empty;

        private string _TokenAlertDuration = string.Empty;
        

        public String HasDelegationRights
        {
            get { return _HasDelegationRights; }
            set { _HasDelegationRights = value; }
        }

        public String RoleCode
        {
            get { return _RoleCode; }
            set { _RoleCode = value; }
        }
        
        public String NotiHeader
        {
            get { return _NotiHeader; }
            set { _NotiHeader = value; }
        }

        public String NotiText
        {
            get { return _NotiText; }
            set { _NotiText = value; }
        }

        public String EmpSAPVendCode
        {
            get { return _EmpSAPVendCode; }
            set { _EmpSAPVendCode = value; }
        }

        public String ShowNotification
        {
            get { return _ShowNotification; }
            set { _ShowNotification = value; }
        }
public String RoleDesc
        {
            get { return _RoleDesc; }
            set { _RoleDesc = value; }
        }


        public String Department
        {
            get { return _Department; }
            set { _Department = value; }
        }

        public String AuthToken
        {
            get { return _AuthToken; }
            set { _AuthToken = value; }
        }

        public String AuthTokenDuration
        {
            get { return _AuthTokenDuration; }
            set { _AuthTokenDuration = value; }
        }

        public String TokenAlertDuration
        {
            get { return _TokenAlertDuration; }
            set { _TokenAlertDuration = value; }
        }
        #endregion

        #region " Properties "

        //public string UserName { get; set; }
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }



        private string _IsProfileUpdated;
        public string IsProfileUpdated
        {
            get { return _IsProfileUpdated; }
            set { _IsProfileUpdated = value; }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private string _IsSuccess;
        public string IsSuccess
        {
            get { return _IsSuccess; }
            set { _IsSuccess = value; }
        }

        private string _Imei;
        public string Imei
        {
            get { return _Imei; }
            set { _Imei = value; }
        }

        private string _UDID;
        public string UDID
        {
            get { return _UDID; }
            set { _UDID = value; }
        }

        private string _Platform;
        public string Platform
        {
            get { return _Platform; }
            set { _Platform = value; }
        }

        private string _Model;
        public string Model
        {
            get { return _Model; }
            set { _Model = value; }
        }

        private string _DeviceType;
        public string DeviceType
        {
            get { return _DeviceType; }
            set { _DeviceType = value; }
        }

        private string _OSVersion;
        public string OSVersion
        {
            get { return _OSVersion; }
            set { _OSVersion = value; }
        }

        private string _ErrMsg;
        public string ErrMsg
        {
            get { return _ErrMsg; }
            set { _ErrMsg = value; }
        }

        private string _EmpProfMsg;
        public string EmpProfMsg
        {
            get { return _EmpProfMsg; }
            set { _EmpProfMsg = value; }
        }

        private string _UserToken;
        public string UserToken
        {
            get { return _UserToken; }
            set { _UserToken = value; }
        }

        private String _CurrRoleCode = String.Empty;
        private String _CurrRoleDesc = String.Empty;

        public bool IsArchiveMode
        {
            get { return _IsArchiveMode; }
            set { _IsArchiveMode = value; }
        }
        public String CurrRoleCode
        {
            get { return _CurrRoleCode; }
            set { _CurrRoleCode = value; }
        }

        public String CurrRoleDesc
        {
            get { return _CurrRoleDesc; }
            set { _CurrRoleDesc = value; }
        }

        public String RoleID
        {
            get { return _RoleID; }
            set { _RoleID = value; }
        }

        public String Roles
        {
            get { return _Roles; }
            set { _Roles = value; }
        }

        public String CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }

        private String _IsImprest = String.Empty;
        public String IsImprest
        {
            get { return _IsImprest; }
            set { _IsImprest = value; }
        }

        private String _IsHR = String.Empty;
        public String IsHR
        {
            get { return _IsHR; }
            set { _IsHR = value; }
        }

        private String _IsCentralInsurance = String.Empty;
        public String IsCentralInsurance
        {
            get { return _IsCentralInsurance; }
            set { _IsCentralInsurance = value; }
        }
        public String CreatedOn
        {
            get { return _CreatedOn; }
            set { _CreatedOn = value; }
        }

        public String LModBy
        {
            get { return _LModBy; }
            set { _LModBy = value; }
        }

        public String LModOn
        {
            get { return _LModOn; }
            set { _LModOn = value; }
        }



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

        public Int64 EmpID
        {
            get
            {
                return _EmpID;
            }
            set
            {
                _EmpID = value;

            }
        }

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

        public String EmailAdd
        {
            get
            {
                return _EmailAdd;
            }
            set
            {
                _EmailAdd = value;

            }
        }



        public UserPropertiesSC UserProperties
        {
            get
            {
                return _UserProperties;
            }
            set
            {
                _UserProperties = value;
            }

        }

        #endregion

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public UserObjectSC Clone()
        {
            return (UserObjectSC)this.MemberwiseClone();
        }


        public bool _IsArchiveMode { get; set; }

        public static implicit operator UserObjectSC(string v)
        {
            throw new NotImplementedException();
        }


    } //End Class
}
