var EmployeeViewObj = {
    Add() {
      debugger;
      PageHelper.Redirect(_RootUrl + "Employee/New");
    },
  
    Load() {
      debugger;
      var Type = $("#FltrActive").val();
      var IsHoldSurv = $("input:checkbox[name=chkHoldSurvey]:checked").val();
  
      var mGrid = new BZComp.DataGrid();
      mGrid.Config = {
        Id: "EmployeeGrid",
        DataUrl:
          _RootUrl +
          "Employee/GetViewData/" +
          Type +
          "?IsHoldSurvey=" +
          IsHoldSurv,
        ColList: [
          //Your Columns List //name is used for server side sorting
          { data: "EmpId", name: "EmpId", autoWidth: true },
          {
            data: "EmpName",
            title: "Employee Name",
            name: "EmpName",
            autoWidth: true,
            WordDecor: true,
          },
          {
            data: "EmpCode",
            title: "Employee Code",
            name: "EmpCode",
            autoWidth: true,
          },
          { data: "Email", title: "Email Id", name: "EmailId", autoWidth: true },
          {
            data: "LpRating",
            title: "LP Rating",
            name: "LPRating",
            autoWidth: true,
          },
        ],
  
        HideCols: ["EmpId"],
        FormId: "EmpId",
        FormEditURL: _RootUrl + "Employee/Edit/",
        FormButtons: ["EDIT"],
        ProcessOnServer: true,
      };
  
      mGrid.Load();
    },
  
    RefreshEmp() {
      EmployeeViewObj.Load();
    },
  };
  
  $(function () {
    debugger;
    EmployeeViewObj.Load();
  });
  