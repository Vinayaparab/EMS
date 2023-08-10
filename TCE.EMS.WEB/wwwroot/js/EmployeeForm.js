var EmployeeFormObj = {
    FormHelperObj: null,
  
    Init() {
      FormHelperObj = new FormHelper();
      FormHelperObj.Init();
    },
  
    OnFormSubStart() {
      FormHelperObj.ShowActionLoader();
    },
  
    OnFormSubCompleted(xhr) {
      var mReturnReceipt = FormHelperObj.ParseResponse(xhr);
  
      if (mReturnReceipt.IsSuccess != true) {
        FormHelperObj.ShowError(mReturnReceipt);
        return;
      }
      FormHelperObj.NotifyUser();
      EmployeeFormObj.ExitPage();
    },
  
    ExitPage() {
      PageHelper.Redirect(_RootUrl + "Employee/DataView");
    },
  };
  
  $(function () {
    EmployeeFormObj.Init();
  });
  