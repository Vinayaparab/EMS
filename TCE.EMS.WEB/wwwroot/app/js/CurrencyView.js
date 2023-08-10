var CurrencyViewObj = {
    Add() {
      debugger;
      PageHelper.Redirect(_RootUrl + "Currency/New");
    },
  
  
  
  
    Load() {
      debugger;
      var Type = $("#FltrActive").val();
      var IsHoldSurv = $("input:checkbox[name=chkHoldSurvey]:checked").val();
      var IsStatus = "";

      var mGrid = new BZComp.DataGrid();
      mGrid.Config = {
        Id: "CurrencyGrid",
        DataUrl: _RootUrl + "Currency/GetViewData/?IsStatus=" + IsStatus,
        // DataUrl:
        //   _RootUrl +
        //   "Currency/GetViewData/" +
        //   Type +
        //   "?IsHoldSurvey=" +
        //   IsHoldSurv,
        ColList: [
          //Your Columns List //name is used for server side sorting
          {
            data: "DocId",
            name: "DocId",
            autoWidth: true,
            
          },
          {
            data: "CurrCode",
            title: "Currency Code",
            name: "CurrCode",
            autoWidth: true,
            
          },
          {
            data: "CurrName",
            title: "Currency Name",
            name: "CurrName",
            autoWidth: true,
          }

        ],
  
        HideCols: ["DocId"],
        FormId: "DocId",
        FormEditURL: _RootUrl + "Currency/Edit/",
        FormButtons: ["EDIT"],
        ProcessOnServer: true,
      };
  
      mGrid.Load();
    },
  
    RefreshEmp() {
      CurrencyViewObj.Load();
    },
  };
  
  
  
  

  
  
  
  // js for poup form ends
  $(function () {
    debugger;
    CurrencyViewObj.Load();
  });
  