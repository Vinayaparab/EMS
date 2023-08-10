
#region " Namespace "
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using TCE.EMS.Services.Models;
using TCE.EMS.Services.DBContext;
using TCE.EMS.Services.EFModels;
using System.Data.OleDb;
using System.Configuration;
using TCE.EMS.Services.DAL;
//using System.Web.UI;
using System.Collections;
using System.Web;
using System.Net.Mail;
using System.Transactions;
//using System.Web.SessionState;

#endregion

namespace  TCE.EMS.Services.DAL;

    public class StoredProcedure
    {
        static UserObjectSC CurrUser = null;

        public static string DBName
        {
            get
            {
                try
                {
                    CurrUser = new UserObjectSC();

                    CurrUser = GetUserSession();
                    if (CurrUser != null && CurrUser.IsArchiveMode == true)
                    {
                        return "EMS_Archive";
                    }
                    else
                    {
                        return "EMS";
                    }
                }
                catch (Exception ex)
                {
                    return "EMS";
                }
            }
            set
            {
                DBName = value;
            }
        }

        public static UserObjectSC GetUserSession()
        {
            //HttpSessionState mPageSession = default(HttpSessionState);

            UserObjectSC mUserObjectSC = null;
            String mURL = String.Empty;

       //     Page mPage = default(Page);
            try
            {
               // mPageSession = HttpContext.Current.Session;
               // mUserObjectSC = (UserObjectSC)mPageSession["UserObj"];
              // mPage = (Page)HttpContext.Current.Handler;
              // mPage.Response.Cache.SetCacheability(HttpCacheability.NoCache);
              //  mURL = mPage.Request.Path;
            }
            catch (Exception ex)
            {
                //ErrorBLL.GetErrorInfo(ex.Message, ex.ToString(), "", null);
                throw ex;
            }

            return mUserObjectSC;
        }

        //public static string DBName = "EMS";

        public const string PullDB = "PullDB";

        public const string PushDB = "PushDB";

        public const string spr_UpdateAdvanceDocument = "[Docs].[spr_UpdateAdvanceDocument]";

        public const string spr_FNFValidate = "[Docs].[spr_FNFValidate]";

        public const string spr_AdvanceReport_GetDataToPrint_new = "[dbo].[spr_AdvanceReport_GetDataToPrint_new]";

        public const string spr_SaveAndContinue_Validate = "[Docs].[spr_SaveAndContinue_Validate]";

        public const string spr_GetLevelOfApprovalForDomTrip = "[Docs].[spr_GetLevelOfApprovalForDomTrip]";

        public const string spr_UpdateFlownStatusForVisitPurposeDtls = "[Docs].[spr_UpdateFlownStatusForVisitPurposeDtls]";

        public const string spr_TE_UpdateFlownStatus = "Docs.spr_TE_UpdateFlownStatus";

        public const string spr_GetListForMultipleSelectionDialog = "Docs.spr_GetListForMultipleSelectionDialog";

        public const string spr_GenAdv_UpdateLogAndInsertIntoACL = "[Docs].[spr_GenAdv_UpdateLogAndInsertIntoACL]";



        public const string spr_TripExt_Validate = "[Docs].[spr_TripExt_Validate]";

        public const string spr_TripExtnVisitPurpose_Save = "[Docs].[spr_TripExtnVisitPurpose_Save]";

        public const string spr_SetReviewFlagForGE_Exp = "[Docs].[spr_SetReviewFlagForGE_Exp]";

        public const string spr_GetViewByAuditor = "Docs.spr_GetViewByAuditor";

        public const string spr_GetJobDtlsForCreateTrip = "[Masters].[spr_GetJobDtlsForCreateTrip]";

        public const string spr_GetDataFromTripDataService = "[DataService].[spr_GetDataFromTripDataService]";

        public const string spr_UpdateUserIDForEmp = "[DataSource].[spr_UpdateUserIDForEmp]";

        public const string spr_UpdateTripStatus = "[DataService].[spr_UpdateTripStatus]";

        public const string spr_CheckIfCityExists = "[Docs].[spr_CheckIfCityExists]";

        public const string spr_UpdateLogAndInsertIntoACL = "[Docs].[spr_UpdateLogAndInsertIntoACL]";


        public const string spr_GetInActiveEmpData = "[DataService].[spr_GetInActiveEmpData]";

        public const string spr_GetLevelOfApprovalForDomTrip_OthEmp = "[Docs].[spr_GetLevelOfApprovalForDomTrip_OthEmp]";

        public const string spr_GetNewTripsForView = "[Docs].[spr_GetNewTripsForView]";

        public const string spr_GetTripFromTripDataService = "[DataService].[spr_GetTripFromTripDataService]";

        public const string spr_TCInsertIntoInvTemp = "[DataService].[spr_TCInsertIntoInvTemp]";

        public const string spr_UpdateTripTable = "[DataService].[spr_UpdateTripTable]";


        public const string spr_CreateTrip_SetDocFlag = "[Docs].[spr_CreateTrip_SetDocFlag]";

        public const string spr_CreateTrip_InsertIntoTrips = "[Config].[spr_CreateTrip_InsertIntoTrips]";

        public const string spr_GenerateTripNo = "Docs.spr_GenerateTripNo";

        public const string spr_GetApproverForNonJobForDomCreateTrip = "[Docs].[spr_GetApproverForNonJobForDomCreateTrip]";

        public const string spr_GetApproverForNonJobForDomCreateTrip_OthEmp = "[Docs].[spr_GetApproverForNonJobForDomCreateTrip_OthEmp]";



        public const string spr_GetApproverGrid_OthEmp = "[Docs].[spr_GetApproverGrid_OthEmp]";

        public const string spr_GetEmpGradeValidation = "[Docs].[spr_GetEmpGradeValidation]";

        public const string spr_GetApproverGrid = "[Docs].[spr_GetApproverGrid]";

        public const string spr_GetDistance = "[Docs].[spr_GetDistance]";

        public const string spr_GetOthEmpDtls = "[Docs].[spr_GetOthEmpDtls]";



        public const string spr_GetConvAmt = "[Docs].[spr_GetConvAmt]";

        public const string spr_FillDropDownOnType = "[Docs].[spr_FillDropDownOnType]";

        public const string spr_GetTravelCardData = "[Docs].[spr_GetTravelCardData]";

        public const string spr_CreateTrip_IsEligibleToCreateDoc = "[Docs].[spr_CreateTrip_IsEligibleToCreateDoc]";



        public const string spr_IsEligibleToApplyForAmount = "[Docs].[spr_IsEligibleToApplyForAmount]";

        public const string spr_AdvanceReportDetail_GetDataToPrint = "[dbo].[spr_AdvanceReportDetail_GetDataToPrint]";

        public const string spr_WF_GetForExcpApproverForImprestExp = "[Docs].[spr_WF_GetForExcpApproverForImprestExp]";

        public const string spr_GetTripVisitDetails = "[Docs].[spr_GetTripVisitDetails]";


        public const string spr_GetPassportDtls = "Docs.spr_GetPassportDtls";

        public const string spr_GetDelegatedUser = "[Docs].[spr_GetDelegatedUser]";

        public const string spr_GetDelegationRights = "[Docs].[spr_GetDelegationRights]";




        public const string spr_IsEligibleToCreateFVR = "[Docs].[spr_IsEligibleToCreateFVR]";


        public const string spr_UpdateEligibilityAmount = "[Docs].[spr_UpdateEligibilityAmount]";

        public const string spr_InsertIntoIEAdvQueue = "[PPR].[spr_InsertIntoIEAdvQueue]";

        public const string spr_InsertIntoIEQueue = "[PPR].[spr_InsertIntoIEQueue]";

        public const string spr_Imprest_GetCalcValues = "[Docs].[spr_Imprest_GetCalcValues]";

        public const string spr_ImprestAdv_IsEligibleToCreateDoc = "[Docs].[spr_ImprestAdv_IsEligibleToCreateDoc]";



        public const string spr_CreateTrip_GetProcessConfigValue = "[Docs].[spr_CreateTrip_GetProcessConfigValue]";

        public const string spr_GetImprestEmpCode = "[Docs].[spr_GetImprestEmpCode]";

        public const string spr_FVRCurrencyDtls_UpdateByED = "[Docs].[spr_FVRCurrencyDtls_UpdateByED]";

        public const string spr_DeleteCurrencyDtls = "[Docs].[spr_DeleteCurrencyDtls]";

        public const string spr_FVRCurrencyDtls_Save = "[Docs].[spr_FVRCurrencyDtls_Save]";

        public const string spr_GetBUDtls = "[Docs].[spr_GetBUDtls]";


        public const string spr_GetImprestBalances = "[Docs].[spr_GetImprestBalances]";


        public const string spr_SendToExpValidator_Validate = "[Docs].[spr_SendToExpValidator_Validate]";

        public const string spr_EarlierExpAmt = "[Docs].[spr_EarlierExpAmt]";

        public const string spr_FRV_CreateTripAndAdvance = "[Docs].[spr_FRV_CreateTripAndAdvance]";

        public const string spr_GetTripExtnDtls = "[Docs].[spr_GetTripExtnDtls]";

        public const string spr_SLAGetAegingData = "[Docs].[spr_SLAGetAegingData]";

        public const string spr_ExportToExcel = "[Docs].[spr_ExportToExcel]";

        public const string spr_SLA_LocationWise = "[Docs].[spr_SLA_LocationWise]";

        public const string spr_GetFromToDate = "[Docs].[spr_GetFromToDate]";

        public const string spr_CommitUploadedData = "[Docs].[spr_CommitUploadedData]";

        public const string spr_ValidateAutoUpload = "[Docs].[spr_ValidateAutoUpload]";

        public const string spr_GetPendingExpensesForEmp = "[Docs].[spr_GetPendingExpensesForEmp]";



        public const string spr_GetEDMDForFVR = "[Docs].[spr_GetEDMDForFVR]";  //added by sohaib
        public const string spr_GetMDForFVR = "[Docs].[spr_GetMDForFVR]";  //added by sohaib

        public const string spr_GetMDForFVR_OthEmp = "[Docs].[spr_GetMDForFVR_OthEmp]";

        public const string spr_GetApproverForJobForFVR = "[Docs].[spr_GetApproverForJobForFVR]";  //added by sohaib

        public const string spr_GetEDMDForFVR_OthEmp = "[Docs].[spr_GetEDMDForFVR_OthEmp]";



        public const string spr_GetApproverForJobForFVR_OthEmp = "[Docs].[spr_GetApproverForJobForFVR_OthEmp]";


        public const string spr_insertFVR = "[dbo].[spr_insertFVR]";  //added by sohaib

        public const string spr_deleteVP = "[dbo].[spr_deleteVP]";  //added by sohaib

        public const string spr_insertFVRVP = "[dbo].[spr_insertFVRVP]";   //added by sohaib

        public const string spr_selectFVRbyID = "[dbo].[spr_selectFVRbyID]";   //added by sohaib

        public const string spr_selectFVR = "[dbo].[spr_selectFVR]";   //added by sohaib

        public const string spr_GetPassPortDetails = "[Docs].[spr_GetPassPortDetails]";   //added by sohaib

        public const string spr_FRV_SetDocFlag = "[Docs].[spr_FRV_SetDocFlag]";   //added by sohaib

        public const string spr_GetTripAttachmentDtls = "[Docs].[spr_GetTripAttachmentDtls]";   //added by sohaib

        public const string spr_UpdateFVRByApprover = "[Docs].[spr_UpdateFVRByApprover]";   //added by sohaib

        public const string spr_GetLevelOfApproval = "[Docs].[spr_GetLevelOfApproval]";   //added by sohaib

        public const string spr_GetLevelOfApproval_OthEmp = "[Docs].[spr_GetLevelOfApproval_OthEmp]";   //added by sohaib




        public const string spr_GetVendorForLocAdmin = "[Docs].[spr_GetVendorForLocAdmin]";

        public const string spr_GetAllLocationForLocAdmin = "[Docs].[spr_GetAllLocationForLocAdmin]";

        public const string spr_GetAllCompanyForLocAdmin = "[Docs].[spr_GetAllCompanyForLocAdmin]";

        public const string spr_UpdateDocIDStatus = "[Docs].[spr_UpdateDocIDStatus]";

        public const string spr_DeleteFromAutoUpload = "[Docs].[spr_DeleteFromAutoUpload]";



        public const string spr_UpdateDocIDForSAPDocNo = "[Docs].[spr_UpdateDocIDForSAPDocNo]";

        public const string spr_InsertIntoAutoUpload_Temp = "[Docs].[spr_InsertIntoAutoUpload_Temp]";

        public const string spr_GetNextPID = "[Docs].[spr_GetNextPID]";

        public const string spr_ClearInvTemp = "[Docs].[spr_ClearInvTemp]";

        public const string spr_GetLocation = "[Docs].[spr_GetLocation]";

        public const string spr_GetReqType = "[Docs].[spr_GetReqType]";

        public const string spr_ImprestAdv_GetAdvAmt = "[Docs].[spr_ImprestAdv_GetAdvAmt]";

        public const string spr_ImprestExp_IsEligibleToCreateDoc = "[Docs].[spr_ImprestExp_IsEligibleToCreateDoc]";
        

        public const string spr_ValidateAmountForDestDtls = "[Docs].[spr_ValidateAmountForDestDtls]";

        public const string spr_Invoice_Delete = "[Docs].[spr_Invoice_Delete]";

        public const string spr_Imprest_Adv_ValidOnSendForApproval = "[Docs].[spr_Imprest_Adv_ValidOnSendForApproval]";

        public const string spr_ChangeTripDate = "[Docs].[spr_ChangeTripDate]";

        public const string spr_Trip_GetListForLocAdmin = "[Docs].[spr_Trip_GetListForLocAdmin]";

        public const string spr_CreditVerification_DeliveredList = "[Docs].[spr_CreditVerification_DeliveredList]";

        public const string spr_InvVerification_DeliveredList = "[Docs].[spr_InvVerification_DeliveredList]";

        public const string spr_GetAllowedRatePercent = "[Docs].[spr_GetAllowedRatePercent]";

        public const string spr_GetJobDtlsForImprest = "[Masters].[spr_GetJobDtlsForImprest]";

        public const string spr_GetEmpFromAccessTable = "[Docs].[spr_GetEmpFromAccessTable]";

        public const string spr_ImpressAdv_SaveByFinance = "[Docs].[spr_ImpressAdv_SaveByFinance]";

        public const string spr_ImpAdv_SetDocFlag = "[Docs].[spr_ImpAdv_SetDocFlag]";

        public const string spr_WF_GetHOD = "[Docs].[spr_WF_GetHOD]";

        public const string spr_WF_GetReportingManager = "[Docs].[spr_WF_GetReportingManager]";

        public const string spr_InvDtls_UpdateByFinance = "[Docs].[spr_InvDtls_UpdateByFinance]";

        public const string spr_RevertInvDtls = "[Docs].[spr_RevertInvDtls]";

        public const string spr_RevertCRNDtls = "[Docs].[spr_RevertCRNDtls]";

        public const string spr_RevertFlownStatus = "[Docs].[spr_RevertFlownStatus]";

        public const string spr_UpdateInvDtls = "[Docs].[spr_UpdateInvDtls]";

        public const string spr_UpdateCRNDtls = "[Docs].[spr_UpdateCRNDtls]";

        public const string spr_RemoveAttachment = "[Docs].[spr_RemoveAttachment]";

        public const string spr_Agent_PullTripDtls = "[Config].[spr_Agent_PullTripDtls]";

        public const string spr_InsertIntoIntlTemp = "[Docs].[spr_InsertIntoIntlTemp]";

        public const string spr_InsertIntoDomTemp = "[Docs].[spr_InsertIntoDomTemp]";

        public const string spr_IntlAdvDtls_GetList = "[Docs].[spr_IntlAdvDtls_GetList]";

        public const string spr_IntlExpDtls_GetList = "[Docs].[spr_IntlExpDtls_GetList]";


        public const string spr_GenAdvDtls_GetList = "[Docs].[spr_GenAdvDtls_GetList]";

        public const string spr_GenExpDtls_GetList = "[Docs].[spr_GenExpDtls_GetList]";



        public const string spr_DomExpDtls_GetList = "[Docs].[spr_DomExpDtls_GetList]";

        public const string spr_DomAdvDtls_GetList = "[Docs].[spr_DomAdvDtls_GetList]";

        public const string spr_InsertIntoInvTemp = "[Docs].[spr_InsertIntoInvTemp]";

        public const string spr_UpdateFlownStatusByAdmin = "[Docs].[spr_UpdateFlownStatusByAdmin]";

        public const string spr_UpdateFlownStatus = "[Docs].[spr_UpdateFlownStatus]";

        public const string spr_InsertInvoices = "[PPR].[spr_InsertInvoices]";

        public const string spr_Credit_Cancel = "[Docs].[spr_Credit_Cancel]";

        public const string spr_InsertCreditNotes = "[PPR].[spr_InsertCreditNotes]";

        public const string spr_GetSQLDateTime = "[Docs].[spr_GetSQLDateTime]";

        public const string spr_WF_GetJobPM = "[Masters].[spr_WF_GetJobPM]";

        public const string spr_TE_Exp_GetDataForLineItems = "[Docs].[spr_TE_Exp_GetDataForLineItems]";

        public const string spr_GetMailOutboxByMailID = "Mail.spr_GetMailOutboxByMailID";

        public const string spr_WF_GetApproverForTravel = "[Masters].[spr_WF_GetApproverForTravel]";

        public const string spr_GetDupExpCatList = "[Docs].[spr_GetDupExpCatList]";

        public const string spr_UpdateRefNoForExp = "[Docs].[spr_UpdateRefNoForExp]";

        public const string spr_GetMaxAmount = "[Docs].[spr_GetMaxAmount]";

        public const string spr_AdvanceReport_GetDataToPrint = "[dbo].[spr_AdvanceReport_GetDataToPrint]";



        public const string spr_CalcBal_Delete = "[Docs].[spr_CalcBal_Delete]";

        public const string spr_TEExpCurrency_Validate = "[Docs].[spr_TEExpCurrency_Validate]";

        public const string spr_GetApprForNonJobForTA = "[Docs].[spr_GetApprForNonJobForTA]";

        public const string spr_UpdateRefNoDocID = "[Docs].[spr_UpdateRefNoDocID]";

        public const string spr_GetCurrListForTE = "[Docs].[spr_GetCurrListForTE]";

        public const string spr_GetApprForNonJobForTE = "[Docs].[spr_GetApprForNonJobForTE]";

        public const string spr_TA_ValdOnReview = "[Docs].[spr_TA_ValdOnReview]";

        public const string spr_GetSelectedCompCurrency = "[Masters].[spr_GetSelectedCompCurrency]";

        public const string spr_GeneralExp_GetListView = "[Docs].[spr_GeneralExp_GetListView]";

        public const string spr_GeneralAdv_GetListView = "[Docs].[spr_GeneralAdv_GetListView]";

        public const string spr_TravelExp_GetListView = "[Docs].[spr_TravelExp_GetListView]";

        public const string spr_TravelAdv_GetList = "[Docs].[spr_TravelAdv_GetList]";

        public const string spr_GetEmpBUBelongsToCODC = "[Docs].[spr_GetEmpBUBelongsToCODC]";
        //Credit Note
        public const string spr_Credit_SetDocFlag = "[Docs].[spr_Credit_SetDocFlag]";

        public const string spr_CreditVerify_Save = "[Docs].[spr_CreditVerify_Save]";

        public const string spr_CreditDelivered_GetList = "[Docs].[spr_CreditDelivered_GetList]";

        public const string spr_CreditPendingForDelivery_GetList = "[Docs].[spr_CreditPendingForDelivery_GetList]";

        public const string spr_tbl_CreditVerifyDtls_Save = "[Docs].[spr_tbl_CreditVerifyDtls_Save]";

        public const string spr_CreditVerification_GetList = "[Docs].[spr_CreditVerification_GetList]";

        public const string spr_GetCreditAmountDtls = "[Docs].[spr_GetCreditAmountDtls]";



        public const string spr_CreditVerifyDtls_GetList = "[Docs].[spr_CreditVerifyDtls_GetList]";

        public const string spr_CreditVerify_Get = "[Docs].[spr_CreditVerify_Get]";

        public const string spr_SendMailToHR = "[Mail].[spr_SendMailToHR]";

        public const string spr_Credit_Dtls_Get = "[Docs].[spr_Credit_Dtls_Get]";

        public const string spr_DB_GetData = "[Docs].[spr_DB_GetData]";

        public const string spr_GE_Exp_SetStatusFlag = "[Docs].[spr_GE_Exp_SetStatusFlag]";

        public const string spr_InsertIntoGEQueue = "[PPR].[spr_InsertIntoGEQueue]";

        public const string spr_TE_Adv_SetStatusFlag = "[Docs].[spr_TE_Adv_SetStatusFlag]";

        public const string spr_InsertIntoTEAdvQueue = "[PPR].[spr_InsertIntoTEAdvQueue]";

        public const string spr_GetMyIntlTravels = "[Docs].[spr_GetMyIntlTravels]";

        public const string spr_GeneralExpDtls_SaveByFinance = "[Docs].[spr_GeneralExpDtls_SaveByFinance]";

        public const string spr_GeneralAdvDtls_SaveByFinance = "[Docs].[spr_GeneralAdvDtls_SaveByFinance]";

        public const string spr_GetCountryName = "[Docs].[spr_GetCountryName]";

        public const string spr_GetRecieptCurrency = "[Docs].[spr_GetRecieptCurrency]";

        public const string spr_TE_Exp_SetStatusFlag = "[Docs].[spr_TE_Exp_SetStatusFlag]";

        public const string spr_Reimbursable_GetMasterListForFin = "[Docs].[spr_Reimbursable_GetMasterListForFin]";

        public const string spr_Reimbursable_GetMasterList = "[Docs].[spr_Reimbursable_GetMasterList]";

        public const string spr_Reimbursable_Save = "[Docs].[spr_Reimbursable_Save]";

        public const string spr_InsertIntoGEAdvQueue = "[PPR].[spr_InsertIntoGEAdvQueue]";

        public const string spr_InsertFRXInvoices = "[PPR].[spr_InsertFRXInvoices]";



        public const string spr_ReimbursableDtls_Save = "[Docs].[spr_ReimbursableDtls_Save]";

        public const string spr_GetApproverForNonJob = "[Docs].[spr_GetApproverForNonJob]";

        public const string spr_GetApproverForNonJob_OthEmp = "[Docs].[spr_GetApproverForNonJob_OthEmp]";

        public const string spr_Reimbursable_GetList = "[Docs].[spr_Reimbursable_GetList]";

        public const string spr_FillExpTypeDropDown = "[Docs].[spr_FillExpTypeDropDown]";

        public const string spr_spr_Reimbursable_ApprovedGetList = "[Docs].[spr_spr_Reimbursable_ApprovedGetList]";

        public const string spr_GetAtctualsList = "[Docs].[spr_GetAtctualsList]";



        public const string spr_ValidateData = "[Docs].[spr_ValidateData]";

        public const string spr_GetUploadedDataSet = "[Docs].[spr_GetUploadedDataSet]";

        public const string spr_TE_Exp_UpdateSettleFlag = "[Docs].[spr_TE_Exp_UpdateSettleFlag]";

        public const string spr_InvTicket_Update = "[Docs].[spr_InvTicket_Update]";

        public const string spr_InvVerify_Save = "[Docs].[spr_InvVerify_Save]";

        public const string spr_PendingForDelivery_GetList = "[Docs].[spr_PendingForDelivery_GetList]";

        public const string spr_InvoiceDelivered_GetList = "[Docs].[spr_InvoiceDelivered_GetList]";

        public const string spr_GenExp_IsReview = "[Docs].[spr_GenExp_IsReview]";

        public const string spr_GetAssignedCompanyDropDownList = "[Docs].[spr_GetAssignedCompanyDropDownList]";

        public const string spr_GetCompanyDropDownList = "[Docs].[spr_GetCompanyDropDownList]";

        public const string spr_InvVerify_Get = "[Docs].[spr_InvVerify_Get]";

        public const string spr_InvVerifyDtls_Save = "[Docs].[spr_InvVerifyDtls_Save]";

        public const string spr_InvVerifyDtls_GetList = "[Docs].[spr_InvVerifyDtls_GetList]";

        public const string spr_getUserMessages = "[Docs].[spr_getUserMessages]";

        public const string spr_GetSLADBData = "[Docs].[spr_GetSLADBData]";

        public const string spr_DeleteUpload = "[Docs].[spr_DeleteUpload]";

        public const string spr_Upload_GetMasterData = "[Docs].[spr_Upload_GetMasterData]";

        public const string spr_GenExp_IsBillAttached = "[Docs].[spr_GenExp_IsBillAttached]";

        public const string spr_InvVerification_GetList = "[Docs].[spr_InvVerification_GetList]";

        public const string spr_GetInvAmountDtls = "[Docs].[spr_GetInvAmountDtls]";



        public const string spr_GetInvoiceApprover = "[Masters].[spr_GetInvoiceApprover]";

        public const string spr_Invoice_SetDocFlag = "[Docs].[spr_Invoice_SetDocFlag]";

        public const string spr_Invoice_Cancel = "[Docs].[spr_Invoice_Cancel]";

        public const string spr_Invoice_UpdateInvoice = "[Docs].[spr_Invoice_UpdateInvoice]";


        public const string InvDtls_Get = "[Docs].[InvDtls_Get]";



        public const string spr_FillDropDownList = "[Masters].[spr_FillDropDownList]";

        public const string spr_TA_FillCurrencyList = "[Masters].[spr_TA_FillCurrencyList]";

        public const string spr_TA_FillCurrencyList_ForGE = "[Masters].[spr_TA_FillCurrencyList_ForGE]";

        public const string spr_Invoice_Dtls_Get = "[Docs].[spr_Invoice_Dtls_Get]";

        public const string spr_Category_GetList = "[Masters].[spr_Category_GetList]";

        public const string spr_Category_Save = "[Masters].[spr_Category_Save]";

        public const string spr_Category_Get = "[Masters].[spr_Category_Get]";

        public const string spr_Category_Validate = "[Masters].[spr_Category_Validate]";

        public const string spr_GetExpType = "[Docs].[spr_GetExpType]";

        public const string spr_TA_ValdOnCancel = "[Docs].[spr_TA_ValdOnCancel]";

        public const string spr_GA_ValdOnCancel = "[Docs].[spr_GA_ValdOnCancel]";

        public const string spr_TE_Adv_SetDocFlag = "[Docs].[spr_TE_Adv_SetDocFlag]";

        public const string spr_TA_UpdateAmountOnDelv = "[Docs].[spr_TA_UpdateAmountOnDelv]";

        public const string spr_TA_UpdateDtlsOnDelv = "[Docs].[spr_TA_UpdateDtlsOnDelv]";

        public const string spr_GetAttachmentByAttachID = "[Docs].[spr_GetAttachmentByAttachID]";

        public const string spr_Trip_MyTripDtls_GetList = "[Docs].[spr_Trip_MyTripDtls_GetList]";

        public const string spr_FVR_MyTripDtls_GetList = "[Docs].[spr_FVR_MyTripDtls_GetList]";




        public const string spr_Trip_GetPendingPO_List = "[Docs].[spr_Trip_GetPendingPO_List]";

        public const string spr_Trip_GetPendingInsu_List = "[Docs].[spr_Trip_GetPendingInsu_List]";

        public const string spr_GetOutsourcedEmpDtls = "[Masters].[spr_GetOutsourcedEmpDtls]";

        public const string spr_GeneralExp_GetAttachList = "[Docs].[spr_GeneralExp_GetAttachList]";

        public const string spr_GetAttachResponseData = "[Docs].[spr_GetAttachResponseData]";

        public const string spr_TA_ValdOnApproval = "[Docs].[spr_TA_ValdOnApproval]";

        public const string spr_TE_Exp_SetDocFlag = "[Docs].[spr_TE_Exp_SetDocFlag]";

        public const string spr_TE_UpdateDestDtlsOnSettle = "[Docs].[spr_TE_UpdateDestDtlsOnSettle]";




        public const string spr_IsBillAttached = "[Docs].[spr_IsBillAttached]";

        public const string spr_Dest_TraExpDtls_OnSettleSave = "[Docs].[spr_Dest_TraExpDtls_OnSettleSave]";



        public const string spr_TE_CalcBalances = "[Docs].[spr_TE_CalcBalances]";




        public const string spr_TE_Adv_Update = "[Docs].[spr_TE_Adv_Update]";

        public const string spr_TExp_FBPass_RemoveAttach = "[Docs].[spr_TExp_FBPass_RemoveAttach]";

        public const string spr_TE_Summary_Get = "[Docs].[spr_TE_Summary_Get]";

        public const string spr_TE_GetExpSummary = "[Docs].[spr_TE_GetExpSummary]";

        public const string spr_GetErrMsgForPrevExp = "[Docs].[spr_GetErrMsgForPrevExp]";



        public const string spr_TExp_ToBPass_RemoveAttach = "[Docs].[spr_TExp_ToBPass_RemoveAttach]";

        public const string spr_SaveAndContGE = "[Docs].[spr_SaveAndContGE]";

        public const string spr_IsEmpProfExists = "[Docs].[spr_IsEmpProfExists]";



        public const string spr_GeneralExp_RemoveAttach = "[Docs].[spr_GeneralExp_RemoveAttach]";

        public const string spr_GeneralExpDtls_SendToFinance = "[Docs].[spr_GeneralExpDtls_SendToFinance]";

        public const string spr_GeneralExpDtls_Delivered = "[Docs].[spr_GeneralExpDtls_Delivered]";

        public const string spr_GeneralExpDtls_Save = "[Docs].[spr_GeneralExpDtls_Save]";

        public const string spr_GE_ADV_TotAmt_Get = "[Docs].[spr_GE_ADV_TotAmt_Get]";

        public const string spr_TA_ValdOnDelivery = "[Docs].[spr_TA_ValdOnDelivery]";




        //MyTripDtls

        public const string spr_Update_AttachIdInTExp = "[Docs].[spr_Update_AttachIdInTExp]";

        public const string spr_Trip_ExpDtls_Get = "[Docs].[spr_Trip_ExpDtls_Get]";

        public const string spr_Trip_AdvDtls_Get = "[Docs].[spr_Trip_AdvDtls_Get]";
        public const string spr_TE_Dest_ExpDtls_Delete = "[Docs].[spr_TE_Dest_ExpDtls_Delete]";
        public const string spr_UpdateExistingPO = "[Docs].[spr_UpdateExistingPO]";
        public const string spr_TExpDest_Update_ReimbType = "[Docs].[spr_TExpDest_Update_ReimbType]";
        public const string spr_TExpDest_Update_UpdateByApprover = "[Docs].[spr_TExpDest_Update_UpdateByApprover]";
        public const string spr_TE_Exp_Dest_Get = "[Docs].[spr_TE_Exp_Dest_Get]";
        public const string spr_TE_Get_ForexCurr = "[Docs].[spr_TE_Get_ForexCurr]";

        public const string spr_TA_GetDocMsg = "[Docs].[spr_TA_GetDocMsg]";



        public const string spr_Trip_GetBasicDetails = "[Docs].[spr_Trip_GetBasicDetails]";
        public const string spr_GetddlCurrencyDtls = "[Docs].[spr_GetddlCurrencyDtls]";
        public const string spr_CreateTravelExp = "[Docs].[spr_CreateTravelExp]";
        public const string spr_TravelExp_ValidateOnCreate = "[Docs].[spr_TravelExp_ValidateOnCreate]";
        public const string spr_TravelExp_Get = "[Docs].[spr_TravelExp_Get]";
        public const string spr_GetTExp_ProfDtls = "[Docs].[spr_GetTExp_ProfDtls]";
        public const string spr_TravelExp_Save = "[Docs].[spr_TravelExp_Save]";
        public const string spr_GetddlCityDtls = "[Docs].[spr_GetddlCityDtls]";
        public const string spr_TE_Adv_GetList = "[Docs].[spr_TE_Adv_GetList]";
        public const string spr_Update_TEDest_Dtls = "[Docs].[spr_Update_TEDest_Dtls]";
        public const string spr_GetddlCountryDtls = "[Docs].[spr_GetddlCountryDtls]";
        public const string spr_Dest_TravelExpDtls_Save = "[Docs].[spr_Dest_TravelExpDtls_Save]";
        public const string spr_GetddlModeOfPay = "[Docs].[spr_GetddlModeOfPay]";

        public const string spr_InsuranceDtls_Update = "[Docs].[spr_InsuranceCopy_Update]";

        public const string spr_TicketDtls_Update = "[Docs].[spr_TicketCopy_Update]";

        public const string spr_InsuAppDtls_Update = "[Docs].[spr_InsuAppDtls_Update]";

        public const string spr_PODtls_Update = "[Docs].[spr_PODtls_Update]";

        public const string spr_Trip_GetExistingPO = "[Docs].[spr_Trip_GetExistingPO]";

        public const string spr_Get_CheckValidatorMsg = "[Docs].[spr_Get_CheckValidatorMsg]";


        // MyProfile

        public const string spr_UpdateAttachment = "[Docs].[spr_UpdateAttachment]";

        public const string spr_MyProfile_Get = "[Docs].[spr_MyProfile_Get]";

        public const string spr_MyProfile_Save = "[Docs].[spr_MyProfile_Save]";

        public const string spr_MyProfilePassport_Delete = "[Docs].[spr_MyProfile_RemoveAttach]";

        public const string spr_Authenticate = "[dbo].[spr_User_AuthUser]";

        public const string spr_GetCurrentFY = "[Masters].[spr_GetCurrentFY]";

        public const string spr_GetDomBankDtls = "[Masters].[spr_GetDomBankDtls]";

        public const string spr_GetJobDtls = "[Masters].[spr_GetJobDtls]";

        public const string spr_GetCompCurrency = "[Masters].[spr_GetCompCurrency]";

        //GeneralExpense

        public const string spr_GeneralExp_Save = "[Docs].[spr_GeneralExp_Save]";

        public const string spr_GeneralExpDtls_Delete = "[Docs].[spr_GeneralExpDtls_Delete]";

        public const string spr_WF_GetBUHeadForGenExp = "[Masters].[spr_WF_GetBUHeadForGenExp]";



        public const string spr_GeneralExp_Get = "[Docs].[spr_GeneralExp_Get]";

        public const string spr_GeneralExp_GetList = "[Docs].[spr_GeneralExp_GetList]";

        public const string spr_GetJobDtlsByAdv = "[Masters].[spr_GetJobDtlsByAdv]";

        public const string spr_GE_UpdateOnSettle = "[Docs].[spr_GE_UpdateOnSettle]";

        public const string spr_GE_GetCurrency = "[Masters].[spr_GE_GetCurrency]";

        public const string spr_GeneralExpDtls_SaveForApp = "[Docs].[spr_GeneralExpDtls_SaveForApp]";

        public const string spr_GeneralExpDtls_RemoveAppComnt = "[Docs].[spr_GeneralExpDtls_RemoveAppComnt]";

        public const string spr_GE_CalcBalances = "[Docs].[spr_GE_CalcBalances]";

        public const string spr_GeneralExpDtls_SaveForAppComnt = "[Docs].[spr_GeneralExpDtls_SaveForAppComnt]";

        public const string spr_CheckDuplicatExpTypAndDate = "[Docs].[spr_CheckDuplicatExpTypAndDate]";

        #region " Home page "



        public const string spr_GetAllPendingDocsWithCashier = "[Docs].[spr_GetAllPendingDocsWithCashier]";

        public const string spr_GetMyTripDetails = "[Docs].[spr_GetMyTripDetails]";

        #endregion

        //TravelAdvance

        public const string spr_GetMyTrips = "[Docs].[spr_GetMyTrips]";

        public const string spr_TA_ValdOnCreation = "[Docs].[spr_TA_ValdOnCreation]";
        public const string spr_TravelAdv_ValidateOnCreate = "[Docs].[spr_TravelAdv_ValidateOnCreate]";


        public const string spr_CreateTravelAdv = "[Docs].[spr_CreateTravelAdv]";
        public const string spr_GetTripTypeDtls = "[Docs].[spr_GetTripTypeDtls]";
        public const string spr_Trip_GetDetails = "[Docs].[spr_Trip_GetDetails]";
        public const string spr_TravelAdv_Save = "[Docs].[spr_TravelAdv_Save]";
        public const string spr_TravelAdvDtls_Save = "[Docs].[spr_TravelAdvDtls_Save]";
        public const string spr_TravelAdvDtls_SaveByFinance = "[Docs].[spr_TravelAdvDtls_SaveByFinance]";
        public const string spr_TravelAdvDtls_Delete = "[Docs].[spr_TravelAdvDtls_Delete]";
        public const string spr_TravelAdv_Get = "[Docs].[spr_TravelAdv_Get]";

        public const string spr_TE_Get_LoadDestDtls = "[Docs].[spr_TE_Get_LoadDestDtls]";
        public const string spr_TE_Delete_DestDtls = "[Docs].[spr_TE_Delete_DestDtls]";
        public const string spr_TE_Get_ddlDestCurrDtls = "[Docs].[spr_TE_Get_ddlDestCurrDtls]";
        public const string spr_TravelExpDest_Delivered = "[Docs].[spr_TravelExpDest_Delivered]";
        public const string spr_TravelExpDest_Get_Check = "[Docs].[spr_TravelExpDest_Get_Check]";
        public const string spr_TravelExp_ValdForApprover = "[Docs].[spr_TravelExp_ValdForApprover]";

        public const string spr_TExpDest_Update_ForAppUpdate = "[Docs].[spr_TExpDest_Update_ForAppUpdate]";
        public const string spr_TravelExpDtls_RemoveAppComntt = "[Docs].[spr_TravelExpDtls_RemoveAppComntt]";
        public const string spr_TEExpDtls_SaveForAppComnt = "[Docs].[spr_TEExpDtls_SaveForAppComnt]";


        public const string spr_TravelExpDest_Chek_AppComnt = "[Docs].[spr_TravelExpDest_Chek_AppComnt]";



        //EmployeeDetails



        public const string spr_GetEmpCompany = "[Docs].[spr_GetEmpCompany]";

        public const string spr_GetOthEmpCompany = "[Docs].[spr_GetOthEmpCompany]";



        public const string spr_GetEmpData = "[Masters].[spr_GetEmpData]";

        //GeneralAdvance

        public const string spr_GeneralAdv_Save = "[Docs].[spr_GeneralAdv_Save]";

        public const string spr_GeneralAdv_Get = "[Docs].[spr_GeneralAdv_Get]";

        public const string spr_GetLkpData = "[Masters].[spr_GetLkpData]";

        public const string spr_GeneralAdv_GetList = "[Docs].[spr_GeneralAdv_GetList]";

        public const string spr_GeneralAdvDtls_Save = "[Docs].[spr_GeneralAdvDtls_Save]";

        public const string spr_GeneralAdvDtls_Delete = "[Docs].[spr_GeneralAdvDtls_Delete]";

        public const string spr_GE_Adv_SetDocFlag = "[Docs].[spr_GE_Adv_SetDocFlag]";

        public const string spr_GE_Exp_SetDocFlag = "[Docs].[spr_GE_Exp_SetDocFlag]";

        public const string spr_IsValidFunctionOfBU = "[Docs].[spr_IsValidFunctionOfBU]";

        public const string spr_GE_Adv_ValidOnSendForApproval = "[Docs].[spr_GE_Adv_ValidOnSendForApproval]";



        //GeneralAdvance Repeater 
        public const string spr_GetAdvDetails = "[Masters].[spr_GetAdvDetails]";

        public const string spr_IsDeliveryOrCorporate = "[Docs].[spr_IsDeliveryOrCorporate]";

        public const string spr_WF_GetForExpAppForTravelExp = "[Masters].[spr_WF_GetForExpAppForTravelExp]";



        #region " Workflow "


        public const string spr_GetViewByStatus = "Docs.spr_GetViewByStatus";
        public const string spr_GetViewByStatus_Trip = "MOB.spr_GetViewByStatus_Trip";
        public const string spr_GetViewByStatus_Advance = "MOB.spr_GetViewByStatus_Advance";
        public const string spr_WasFinance = "Docs.spr_WasFinance";

        public const string spr_GetDoc = "WF.spr_GetDoc";
        public const string spr_GetDocACL = "WF.spr_GetDocACL";
        public const string spr_SaveDoc = "WF.spr_SaveDoc";
        public const string spr_ClearDocACL = "WF.spr_ClearDocACL";
        public const string spr_AddDocACL = "WF.spr_AddDocACL";
        public const string spr_SendMail = "WF.spr_SendMail";
        public const string spr_SaveCommonWFDoc = "WF.spr_SaveCommonWFDoc";
        public const string spr_IsActionByEntryExistsInACL = "WF.spr_IsActionByEntryExistsInACL";
        public const string spr_DelActionEntryFromACL = "WF.spr_DelActionEntryFromACL";


        #endregion

        public const string spr_InsertIntoTEQueue = "[PPR].[spr_InsertIntoTEQueue]";
        public const string spr_WF_GetPM = "[Masters].[spr_WF_GetPM]";
        public const string spr_GetApprover = "[Masters].[spr_WF_GetApprover]";

        public const string spr_WF_GetApprover_OthEmp = "[Masters].[spr_WF_GetApprover_OthEmp]";

        public const string spr_GetFinace = "[Masters].[spr_WF_GetFinace]";
        public const string spr_GetExpValidatior = "[Masters].[spr_WF_GetExpValidatior]";
        public const string spr_GetEDMD = "[Masters].[spr_WF_GetEDMD]";
        public const string spr_WF_GetBUHead = "[Masters].[spr_WF_GetBUHead]";
        public const string spr_GetCashierApprover = "[Masters].[spr_GetCashierApprover]";

        public const string spr_WF_GetForExceptionApproval = "[Masters].[spr_WF_GetForExceptionApproval]";


        #region Mail

        public const string spr_GetMailTemplate = "[Mail].[spr_GetMailTemplate]";
        public const string spr_GetEmailID = "[Mail].[spr_GetEmailID]";
        public const string spr_GetEmpNameByEmailID = "[Mail].[spr_GetEmpNameByEmailID]";
        public const string spr_AddMailToOutbox = "[Mail].[spr_AddMailToOutbox]";
        public const string spr_GetEmpCodeListFromSP = "[Mail].[spr_GetEmpCodeListFromSP]";
        public const string spr_MailTemplate_GetList = "[Mail].[spr_MailTemplate_GetList]";
        public const string spr_MailTemplate_Save = "[Mail].[spr_MailTemplate_Save]";
        public const string spr_MailTemplateValidate = "[Mail].[spr_MailTemplateValidate]";
        public const string spr_MailTemplate_Get = "[Mail].[spr_MailTemplate_Get]";
        public const string spr_GetURL = "[Mail].[spr_GetURL]";

        #endregion Mail

        //Masters

        //Foregin Exchange Masters
        public const string spr_ForeignExchange_Save = "[Masters].[spr_ForeignExchange_Save]";
        public const string spr_ForeignExchange_Get = "[Masters].[spr_ForeignExchange_Get]";
        public const string spr_ForeignExchange_GetList = "[Masters].[spr_ForeignExchange_GetList]";
        public const string spr_ForeignExchangeMst_Validate = "[Masters].[spr_ForeignExchangeMst_Validate]";



        //OutsourcedEmp Masters
        public const string spr_OutsourcedEmp_Save = "[Masters].[spr_OutsourcedEmp_Save]";
        public const string spr_OutsourcedEmp_Get = "[Masters].[spr_OutsourcedEmp_Get]";
        public const string spr_OutsourcedEmp_GetList = "[Masters].[spr_OutsourcedEmp_GetList]";
        public const string spr_OutsourcedEmp_Validate = "[Masters].[spr_OutsourcedEmp_Validate]";


        //ProcessConfig Masters
        public const string spr_ProcessConfig_Save = "[Masters].[spr_ProcessConfig_Save]";
        public const string spr_ProcessConfig_Get = "[Masters].[spr_ProcessConfig_Get]";
        public const string spr_ProcessConfig_GetList = "[Masters].[spr_ProcessConfig_GetList]";

        public const string spr_ProcessConfigMst_Validate = "[Masters].[spr_ProcessConfigMst_Validate]";


        //Country Masters
        public const string spr_Country_Save = "[Masters].[spr_Country_Save]";
        public const string spr_Country_Get = "[Masters].[spr_Country_Get]";
        public const string spr_Country_GetList = "[Masters].[spr_Country_GetList]";
        public const string spr_CountryMst_Validate = "[Masters].[spr_CountryMst_Validate]";



        //City Masters
        public const string spr_City_Save = "[Masters].[spr_City_Save]";
        public const string spr_City_Get = "[Masters].[spr_City_Get]";
        public const string spr_City_GetList = "[Masters].[spr_City_GetList]";
        public const string spr_GetCountryList = "[Docs].[spr_GetCountryList]";
        public const string spr_CityMst_Validate = "[Masters].[spr_CityMst_Validate]";


        //Common Masters
        public const string spr_Common_GetList = "[Masters].[spr_Common_GetList]";
        public const string spr_Common_Get = "[Masters].[spr_Common_Get]";
        public const string spr_Common_Save = "[Masters].[spr_Common_Save]";

        public const string spr_CommonMst_Validate = "[Masters].[spr_CommonMst_Validate]";



        // Roles View
        public const string spr_Roles_GetList = "[Masters].[spr_Roles_GetList]";



        //UserACL
        public const string spr_UserACL_Save = "[Masters].[spr_UserACL_Save]";
        public const string spr_UserACL_Get = "[Masters].[spr_UserACL_Get]";
        public const string spr_UserACL_GetList = "[Masters].[spr_UserACL_GetList]";
        public const string spr_GetRoleList = "[Docs].[spr_GetRoleList]";

        public const string spr_UserAcl_Validate = "[Masters].[spr_UserAcl_Validate]";

        //Upload To Execl

        public const string spr_UpdateGE_Exp_DtlsUpload = "[Docs].[spr_UpdateGE_Exp_DtlsUpload]";
        public const string spr_Validate_GEExpDtlTemp_Upload = "[Docs].[spr_Validate_GEExpDtlTemp_Upload]";

        //CurrencyMst

        public const string spr_Currency_GetList = "[Masters].[spr_Currency_GetList]";
        public const string spr_Currency_Get = "[Masters].[spr_Currency_Get]";
        public const string spr_CurrencyMst_Validate = "[Masters].[spr_CurrencyMst_Validate]";
        public const string spr_CurrencyMst_Save = "[Masters].[spr_CurrencyMst_Save]";

        //PrintSp
        public const string spr_TE_GetDataToPrint = "[dbo].[spr_TE_GetDataToPrint]";
        public const string spr_TA_GetDataToPrint = "[dbo].[spr_TA_GetDataToPrint]";

        public const string spr_Inv_GetDataToPrint = "[dbo].[spr_Inv_GetDataToPrint]";

        public const string spr_Credit_Delete = "[Docs].[spr_Credit_Delete]";

        public const string spr_Credit_GetDataToPrint = "[dbo].[spr_Credit_GetDataToPrint]";

        //Added by Rupesh on 15-October-2014
        public const string spr_GEA_GetDataToPrint = "[dbo].[spr_GEA_GetDataToPrint]";
        public const string spr_GER_GetDataToPrint = "[dbo].[spr_GER_GetDataToPrint]";

        public const string spr_GetWFDoc = "[WF].[spr_GetWFDoc]";

        public const string spr_IsEligibleForApproving = "[Docs].[spr_IsEligibleForApproving]";

        //Added by Rupesh on 17-October-2014
        public const string spr_ImpressedAdv_GetListView = "[Docs].[spr_ImpressedAdv_GetListView]";
        public const string spr_ImpressedAdv_Save = "[Docs].[spr_ImpressedAdv_Save]";
        public const string spr_ImpressedAdvDtls_Delete = "[Docs].[spr_ImpressedAdvDtls_Delete]";
        public const string spr_ImpressedAdvDtls_Save = "[Docs].[spr_ImpressedAdvDtls_Save]";
        public const string spr_ImpressedAdvDtls_SaveByFinance = "[Docs].[spr_ImpressedAdvDtls_SaveByFinance]";
        public const string spr_ImpressedAdv_Get = "[Docs].[spr_ImpressedAdv_Get]";
        public const string spr_ImpressedAdv_GetList = "[Docs].[spr_ImpressedAdv_GetList]";

        public const string spr_Imperssed_Req_ValdOnCancel = "[Docs].[spr_Imperssed_Req_ValdOnCancel]";
        public const string spr_Impressed_Statement_GetListView = "[Docs].[spr_Impressed_Statement_GetListView]";
        public const string spr_Impressed_Statement_SetStatusFlag = "[Docs].[spr_Impressed_Statement_SetStatusFlag]";
        public const string spr_Impressed_Statement_IsBillAttached = "[Docs].[spr_Impressed_Statement_IsBillAttached]";
        public const string spr_Impressed_Req_TotAmt_Get = "[Docs].[spr_Impressed_Req_TotAmt_Get]";
        public const string spr_GetJobDtlsByImpReq = "[Masters].[spr_GetJobDtlsByImpReq]";
        public const string spr_SaveAndContImpReq = "[Docs].[spr_SaveAndContImpReq]";
        public const string spr_ImpressedStatement_Save = "[Docs].[spr_ImpressedStatement_Save]";
        public const string spr_ImpressedExpDtls_Save = "[Docs].[spr_ImpressedExpDtls_Save]";
        public const string spr_ImpressedStatement_Dtls_RemoveAppComnt = "[Docs].[spr_ImpressedStatement_Dtls_RemoveAppComnt]";
        public const string spr_ImpressedStatement_Dtls_SaveForApp = "[Docs].[spr_ImpressedStatement_Dtls_SaveForApp]";
        public const string spr_ImpressedStatement_Dtls_SaveByFinance = "[Docs].[spr_ImpressedStatement_Dtls_SaveByFinance]";
        public const string spr_ImpressedStatement_Dtls_SaveForAppComnt = "[Docs].[spr_ImpressedStatement_Dtls_SaveForAppComnt]";
        public const string spr_ImpressedStatement_Dtls_SendToFinance = "[Docs].[spr_ImpressedStatement_Dtls_SendToFinance]";
        public const string spr_ImpressedStatement_Dtls_Delete = "[Docs].[spr_ImpressedStatement_Dtls_Delete]";
        public const string spr_ImpressedStatement_Get = "[Docs].[spr_ImpressedStatement_Get]";
        public const string spr_ImpressedStatement_UpdateOnSettle = "[Docs].[spr_ImpressedStatement_UpdateOnSettle]";
        public const string spr_ImpressedStatement_GetList = "[Docs].[spr_ImpressedStatement_GetList]";
        public const string spr_Impressed_Statement_SetDocFlag = "[Docs].[spr_Impressed_Statement_SetDocFlag]";
        public const string spr_ImpressedReq_GetDataToPrint = "[dbo].[spr_ImpressedReq_GetDataToPrint]";
        public const string spr_ImpressedStatement_GetDataToPrint = "[dbo].[spr_ImpressedStatement_GetDataToPrint]";
        public const string spr_ImpressedStatementDtls_Save = "[Docs].[spr_ImpressedStatementDtls_Save]";

        public const string spr_ExpCatReport_GetDataToPrint = "[dbo].[spr_ExpCatReport_GetDataToPrint]";
        public const string spr_AdvPendingReport_GetDataToPrint = "[dbo].[spr_AdvPendingReport_GetDataToPrint]";



        public const string spr_GetEmpFromTripDataService = "[DataService].[spr_GetEmpFromTripDataService]";

        public const string spr_AccessControl_GetList = "[Masters].[spr_AccessControl_GetList]";
        public const string spr_AccessControl_Get = "[Masters].[spr_AccessControl_Get]";
        public const string spr_AccessControl_Validate = "[Masters].[spr_AccessControLMst_Validate]";
        public const string spr_AccessControlMst_Save = "[Masters].[spr_AccessControlMst_Save]";
        public const string spr_AccessControlMst_Delete = "[Masters].[spr_AccessControlMst_Delete]";


        //Trip Extension Request
        public const string spr_TripExtensionReqGetByDocID = "[Docs].[spr_TripExtensionReqGetByDocID]";
        public const string spr_TripExtensionReqGetList = "[Docs].[spr_TripExtensionReqGetList]";
        public const string spr_TripExtensionReqSave = "[Docs].[spr_TripExtensionReqSave]";
        public const string spr_TripGetByTripNo = "[Docs].[spr_TripGetByTripNo]";
        public const string spr_TripExtnReq_SetDocFlag = "[Docs].[spr_TripExtnReq_SetDocFlag]";
        public const string spr_TripExt_GetHRCode = "[Docs].[spr_TripExt_GetHRCode]";
        public const string spr_MyTripsUpdateByTripNo = "[Docs].[spr_MyTripsUpdateByTripNo]";
        public const string spr_TripExtnReqDateValidate = "[Docs].[spr_TripExtnReqDateValidate]";



        public const string spr_MailConfigMast_Save = "[Masters].[spr_MailConfigMast_Save]";
        public const string spr_MailConfigMast_Get = "[Masters].[spr_MailConfigMast_Get]";
        public const string spr_MailConfigMast_GetList = "[Masters].[spr_MailConfigMast_GetList]";
        public const string spr_MailConfigMast_Validate = "[Masters].[spr_MailConfigMast_Validate]";
        public const string spr_MailRemindConfigDtls = "[Masters].[spr_MailRemindConfigDtls]";
        public const string spr_RemindConfigDtlsDelete = "[Masters].[spr_RemindConfigDtlsDelete]";
        public const string spr_RemndConfigDtls = "[Masters].[spr_RemndConfigDtls]";
        public const string spr_RemndConfigDtlsByDtlsID = "[Masters].[spr_RemndConfigDtlsByDtlsID]";

        public const string spr_CreateTrip = "[Docs].[spr_CreateTrip]";
        public const string spr_CreateTrip_Get = "[Docs].[spr_CreateTrip_Get]";

        public const string spr_CreateTrip_TravelDtls_Delete = "[Docs].[spr_CreateTrip_TravelDtls_Delete]";
        public const string spr_CreateTrip_ClientTravelDtls_Delete = "[Docs].[spr_CreateTrip_ClientTravelDtls_Delete]";

        public const string spr_CreateTrip_TravelDtls_Save = "[Docs].[spr_CreateTrip_TravelDtls_Save]";
        public const string spr_CreateTrip_ClientTravelDtls_Save = "[Docs].[spr_CreateTrip_ClientTravelDtls_Save]";
        public const string spr_TE_VisitPupose_Get = "Docs.spr_TE_VisitPupose_Get";
        public const string spr_Attachment_Update = "Docs.spr_Attachment_Update";
        public const string spr_RemoveNewAttachment = "Docs.spr_RemoveNewAttachment";
        public const string spr_InsertIntoDataService_TripDtls = "[DataService].[spr_InsertIntoDataService_TripDtls]";

        // ??

        public const string spr_EmpOth_Save = "[Masters].[spr_EmpOth_Save]";
        public const string spr_GetEmpOthList = "[Docs].[spr_GetEmpOthList]";
        public const string spr_EmpOth_Validate = "[Masters].[spr_EmpOth_Validate]";
        public const string spr_EmpOth_Get = "[Masters].[spr_EmpOth_Get]";
        public const string spr_MyEmployeePassport_Delete = "[Docs].[spr_MyProfile_RemoveAttach_EmpOth]";

        public const string spr_RemoveReimbAttachment = "[Docs].[spr_RemoveReimbAttachment]";

        public const string spr_AccessControl_GetListByColumnName = "[Masters].[spr_AccessControl_GetListByColumnName]";
        public const string spr_getReimbursableTrip = "[Docs].[spr_getReimbursableTrip]";

        public const string spr_ReimbAttach_Save = "[Docs].[spr_ReimbAttach_Save]";
        public const string spr_ReimbAttach_GetList = "[Docs].[spr_ReimbAttach_GetList]";
        public const string spr_ReimbAttach_Get = "Docs.spr_ReimbAttach_Get";
        public const string spr_ReimbAttach_SaveDtls = "[Docs].[spr_ReimbAttach_SaveDtls]";
        public const string spr_AttachReimb_SendMailTo_PM = "Mail.spr_AttachReimb_SendMailTo_PM";
        public const string spr_ReimbAttach_HistoryAttach_Get = "[Docs].[spr_ReimbAttach_HistoryAttach_Get]";
        public const string spr_Validate_ReimbAttach = "[Docs].[spr_Validate_ReimbAttach]";
        public const string spr_GetEmpCodeByTripID = "[Docs].[spr_GetEmpCodeByTripID]";
        public const string IsReimbAttachVisible = "[Docs].[IsReimbAttachVisible]";


        //?
        public const string spr_GetVisitPurpose = "[Docs].[spr_GetVisitPurpose]";
        public const string spr_UpdateAttachmentPurpose = "[Docs].[spr_UpdateAttachmentPurpose]";
        public const string spr_CreateTrip_TripExtn = "[Docs].[spr_CreateTrip_TripExtn]";
        public const string spr_CreateTrip_TravelDtls_Save_TripExtn = "[Docs].[spr_CreateTrip_TravelDtls_Save_TripExtn]";

        //Forex Vendor - Create Invoice

        public const string spr_GetForexAdvanceDtls = "Docs.spr_GetForexAdvanceDtls";
        public const string spr_CreateInvoice_Save = "Docs.spr_CreateInvoice_Save";
        public const string spr_CreateInvoice_SaveDtls = "Docs.spr_CreateInvoice_SaveDtls";
        public const string spr_CreateInvoice_Get = "Docs.spr_CreateInvoice_Get";
        public const string spr_CreateInvoice_CalculateTax = "Docs.spr_CreateInvoice_CalculateTax";
        public const string spr_CreateInvoice_GetApprover = "[Docs].[spr_CreateInvoice_GetApprover]";
        public const string spr_CreateInvoice_ServerValidate = "Docs.spr_CreateInvoice_ServerValidate";
        public const string spr_CreateInvoice_SetDocFlag = "[Docs].[spr_CreateInvoice_SetDocFlag]";
        public const string spr_CreateInvoice_UpdateInvCreatedFlag = "[Docs].[spr_CreateInvoice_UpdateInvCreatedFlag]";
        public const string spr_CreateInvoice_GetDataToPrint = "Docs.spr_CreateInvoice_GetDataToPrint";
        public const string spr_CreateInvoice_GetList = "[Docs].[spr_CreateInvoice_GetList]";
        public const string spr_CreateNewInvoiceVisiblity = "Docs.spr_CreateNewInvoiceVisiblity";

        //Additional Trip Request

        public const string spr_CreateAdditionalTrip = "[Docs].[spr_CreateAdditionalTrip]";
        public const string spr_CreateAdditionalTrip_TravelDtls_Save = "[Docs].[spr_CreateAdditionalTrip_TravelDtls_Save]";
        public const string spr_CreateAdditionalTrip_Get = "Docs.spr_CreateAdditionalTrip_Get";
        public const string spr_CreateAdditionalTrip_TravelDtls_Delete = "[Docs].[spr_CreateAdditionalTrip_TravelDtls_Delete]";
        public const string spr_CreateAdditionalTrip_IsEligibleToCreateDoc = "[Docs].[spr_CreateAdditionalTrip_IsEligibleToCreateDoc]";
        public const string spr_CreateAdditionalTrip_SetDocFlag = "[Docs].[spr_CreateAdditionalTrip_SetDocFlag]";
        public const string spr_AdditionalTrip_InsertIntoTrips = "Config.spr_AdditionalTrip_InsertIntoTrips";
        public const string spr_GetTripVisitPurposeDtls = "Docs.spr_GetTripVisitPurposeDtls";
        public const string spr_GetArchiveDate = "Docs.spr_GetArchiveDate ";
        public const string spr_GetTripStatus = "Docs.spr_GetTripStatus ";

        //GST
        public const string spr_GetGSTFlag = "Docs.spr_GetGSTFlag";
        public const string spr_GetStateList = "Docs.spr_GetStateList";
        public const string spr_ProcessConfig_GetConfigValue = "[Masters].[spr_ProcessConfig_GetConfigValue]";
        public const string spr_GetGSTNo = "[dbo].[spr_GetGSTNo]";
        public const string spr_GetGSTNoListJobWise = "[dbo].[spr_GetGSTNoListJobWise]";
        public const string spr_GetGSTNoListDCWise = "[dbo].[spr_GetGSTNoListDCWise]";

        public const string spr_CheckForExpAutoApproval_GE = "[dbo].[spr_CheckForExpAutoApproval_GE]";
        public const string spr_CheckForExpAutoApproval_TE = "[dbo].[spr_CheckForExpAutoApproval_TE]";

        public const string spr_UpdateLogAndInsertIntoACL_TE = "[dbo].[spr_UpdateLogAndInsertIntoACL_TE]";
        public const string spr_UpdateLogAndInsertIntoACL_GE = "[dbo].[spr_UpdateLogAndInsertIntoACL_GE]";

        public const string spr_HasRightsToCreateDoc = "[Docs].[spr_HasRightsToCreateDoc]";

        //Imprest Sequencing 

        public const string spr_HasPendingDoc = "[Docs].[spr_HasPendingDoc]";
        public const string spr_ImprestExp_PullBackToCreateDoc = "[Docs].[spr_ImprestExp_PullBackToCreateDoc]";
        public const string spr_IsEligibleForApprovingImpressed = "[Docs].[spr_IsEligibleForApprovingImpressed]";

        //AutoSettle
        public const string spr_AutoApproveUnsettledExpDoc = "[Docs].[spr_AutoApproveUnsettledExpDoc]";
        public const string spr_UpdateExpProc = "[Docs].[spr_UpdateExpProc]";
        public const string spr_GetCorpCashierSession = "[Docs].[spr_GetCorpCashierSession]";
        public const string spr_GetSMTPDetails = "[Docs].[spr_GetSMTPDetails]";

        public const string spr_ValidateReasonByTripStartDate = "[Docs].[spr_ValidateReasonByTripStartDate]";

        public const string spr_TRIP_GetDetailsForFVRById = "[dbo].[spr_TRIP_GetDetailsForFVRById]";   //added by Salman

        public  TCE.EMS.Services.Models.UserObjectSC _UserObj { get; set; }

        public const string spr_setVendorDetails = "[Masters].[spr_setVendorDetails]";

        public const string spr_UserACL_Delete = "[Masters].[spr_UserACL_Delete]";
        public const string spr_TripExpList_ForTE = "[Docs].[spr_TripExpList_ForTE]";
       
        public const string spr_ExpGetAegingData = "[Docs].[spr_ExpGetAegingData]";
        public const string spr_ReminderAttachment_save = "[Mail].[spr_ReminderAttachment_save]";
        public const string spr_GetRSAKeyByUserId = "[MOB].[spr_GetRSAKeyByUserId]";
        public const string spr_InsertAuthKeyByUserId = "[MOB].[spr_InsertAuthKeyByUserId]";
        public const string spr_UpdateAuthTokenByUserId = "[MOB].[spr_UpdateAuthTokenByUserId]";
        public const string spr_CloseAuthToken = "[MOB].[spr_CloseAuthToken]";
        public const string spr_GetUserIdByAuthToken = "[MOB].[spr_GetUserIdByAuthToken]";
        public const string spr_Trip_AdditionalTripDtls_GetList = "[Docs].[spr_Trip_AdditionalTripDtls_GetList]";
        public const string spr_insert_VendorDetails = "[Masters].[spr_insert_VendorDetails]";
        public const string spr_GetViewforMyClaims = "[Docs].[spr_GetViewforMyClaims]";
        public const string spr_InvVerify_GetBatchNO = "[Docs].[spr_InvVerify_GetBatchNO]";
        public const string spr_InvVerifyDtls_Remove = "[Docs].[spr_InvVerifyDtls_Remove]";
        public const string spr_AutoSettled_Validation = "[Docs].[spr_AutoSettled_Validation]";
        public const string spr_AutoSettled_ExpDoc = "[Docs].[spr_AutoSettled_ExpDoc]";
        public const string spr_InvVerifyDtls_Get = "[Docs].[spr_InvVerifyDtls_Get]";
        public const string spr_InvVerifyDtls_GetbyInvoiceNo = "[Docs].[spr_InvVerifyDtls_GetbyInvoiceNo]";
        public const string spr_GetBatchNo = "[Docs].[spr_GetBatchNo]";
        public const string spr_InvVerify_Remove = "[Docs].[spr_InvVerify_Remove]";
        public const string spr_InvVerify_Validation = "[Docs].[spr_InvVerify_Validation]";
        public const string spr_Credit_Validation = "[Docs].[spr_Credit_Validation]";
        public const string spr_CrVerify_Remove = "[Docs].[spr_CrVerify_Remove]";

        public const string spr_CrVerify_GetBatchNO = "[Docs].[spr_CrVerify_GetBatchNO]";
        public const string spr_CrVerifyDtls_Remove = "[Docs].[spr_CrVerifyDtls_Remove]";
        public const string SPR_GetCurrentMobAppVersion = "[Mob].[SPR_GetCurrentMobAppVersion]";
        public const string spr_GetHR = "[Masters].[spr_GetHR]";
    }

