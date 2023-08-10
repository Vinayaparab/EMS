var CurrencyFormObj = {
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
  
      if (mReturnReceipt.IsSuccess != "Y") {
        FormHelperObj.ShowError(mReturnReceipt);
        return;
      }
      FormHelperObj.NotifyUser();
      CurrencyFormObj.ExitPage();
    },
  
    ExitPage() {
      PageHelper.Redirect(_RootUrl + "Currency/DataView");
    },
  };
  
  

  $(function () {
    CurrencyFormObj.Init();
  });
  
  
  
  
  