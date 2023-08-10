$.fn.dataTable.ext.errMode = function (settings, helpPage, message) {
  alert(
    "Oops!! An error occured while loading the data. Please try again or contact system admin."
  ); //#TODO Need to see how we can geet error returned by server and display to user. Specially Error id for Developer debugging purpose.
  console.log(message);
};

var BZComp = {
  DataGrid: function () {
    debugger
    this.DefaultConfig = {
      Id: "",
      DataUrl: "",
      ColList: [],
      HideCols: "",
      ColDefs: [],
      ShowFilter: true,
      FilterLabel: "Search :",
      ProcessOnServer: true,
      PageSize: 10,
      ViewDesign: { Height: "flex", HScroll: false },
      Group: { Enabled: false, ColOrder: [], GroupCol: [] },
      InnerTable: {
        Enabled: false,
        DataUrl: "",
        ColList: [],
        Class:
          "table table-striped table-bordered dt-responsive table-hover nowrap",
        Width: "50%",
      },
      FormId: "Id",
      FormEditURL: "",
      FormViewURL: "",
      FormButtons: [],
      RegisterFormEvent: "",
      WordDecor: false,
    };

    this.Config = {};

    var dt;
    var detailRows = [];

    this.Load = function () {
      if ($.fn.DataTable.isDataTable("#" + this.Config.Id)) {
        $("#" + this.Config.Id)
          .dataTable()
          .fnClearTable();
        $("#" + this.Config.Id)
          .dataTable()
          .fnDestroy();
      }

      var defaultConfig = this.DefaultConfig;
      var config = this.Config;
      var defaultKeys = [];
      var definedKeys = [];
      var missingKeys = [];

      for (var item in defaultConfig) {
        defaultKeys.push(item);
      }

      for (var item in config) {
        definedKeys.push(item);
      }

      for (i = 0; i < defaultKeys.length; i++) {
        if (!(definedKeys.indexOf(defaultKeys[i]) > -1)) {
          missingKeys.push(defaultKeys[i]);
        }
      }

      for (i = 0; i < missingKeys.length; i++) {
        for (var item in defaultConfig) {
          if (item == missingKeys[i]) {
            this.Config[item] = this.DefaultConfig[item];
          }
        }
      }

      if (!this.Config.HideCols == "") {
        var TargetCols = [];
        var data = this.Config.ColList;
        var val = this.Config.HideCols;

        for (i = 0; i < val.length; i++) {
          var index = data.findIndex((m) => m.data === val[i]);
          TargetCols.push(index);
        }

        this.Config.ColDefs.push({
          targets: TargetCols,
          visible: false,
          searchable: false, //works on client-side filter
          orderable: false, //works on client-side sorting
        });
      }

      config = this.Config;

      //EDIT BUTTON
      if (
        this.Config.FormButtons.indexOf("EDIT") > -1 ||
        this.Config.FormButtons.indexOf("VIEW") > -1
      ) {
        var EditBtnJson = {
          data: this.Config.FormId,
          title: "Action",
          render: function (data) {
            var EditButton = "";
            var ViewButton = "";
            if (config.FormButtons.indexOf("EDIT") > -1) {
              if (
                config.RegisterFormEvent != null &&
                config.RegisterFormEvent != ""
              ) {
                EditButton =
                  '<button class="btn btn-primary btn-xs" onclick="' +
                  config.RegisterFormEvent +
                  "('" +
                  config.FormEditURL +
                  data +
                  '?IsEdit=1\')"><span class="glyphicon glyphicon-edit"></span> View</button>';
              } else {
                EditButton =
                  '<a class="btn btn-primary btn-xs" href="' +
                  config.FormEditURL +
                  data +
                  '?IsEdit=1"><span class="glyphicon glyphicon-edit"></span> View</a>';
              }
            }
            if (config.FormButtons.indexOf("VIEW") > -1) {
              var ViewButton =
                ' <a class="btn btn-default btn-xs" href="' +
                config.FormViewURL +
                data +
                '"><span class="glyphicon glyphicon-eye-open"></span> View</a>';
            }

            var buttons = EditButton + ViewButton;
            return buttons;
          },
        };

        if (config.FormButtons != [] && config.FormButtons != "") {
          this.Config.ColList.push(EditBtnJson);
        }
      }

      this.ProcessWordDecor();

      if (this.Config.Group.Enabled) {
        this.LoadDataWithGrouping();
      } else {
        this.LoadData();
      }
    };

    this.ProcessWordDecor = function () {
      var CurrObj = this;

      $.each(this.Config.ColList, function (i, item) {
        if (item.WordDecor == true) {
          item.render = function (data, type, full, meta) {
            var Colors = [
              "info",
              "orange",
              "success",
              "purple",
              "warning",
              "info",
              "orange",
              "success",
              "purple",
              "warning",
            ];
            var mRowNoForColor = meta.row + "";
            mRowNoForColor = mRowNoForColor.charAt(mRowNoForColor.length - 1);

            //if (mRowNoForColor > 3) mRowNoForColor = mRowNoForColor - 4;

            return `
            <div class="d-flex align-items-center">
                  <div class="m-r-10"><a
                          class="btn btn-circle d-flex btn-${
                            Colors[mRowNoForColor]
                          } text-white">
                          ${CurrObj.GetFirst2WordsFromStr(data)}
                          </a>
                  </div>
                  <div class="">
                      <h4 class="m-b-0 font-16">${data}</h4>
                  </div>
              </div>
            `;
          };
        }
      });
    };

    this.GetFirst2WordsFromStr = function (vStr) {
      var matches = vStr.match(/\b(\w)/g); // ['J','S','O','N']
      var acronym = matches.join(""); // JSON
      acronym = acronym.slice(0, 2);
      if ((acronym.length = 1)) acronym = acronym + acronym;

      return acronym.toUpperCase().slice(0, 2);
    };

    this.LoadData = function () {
      dt = $("#" + this.Config.Id).DataTable({
        ajax: {
          url: this.Config.DataUrl,
          type: "POST",
          datatype: "json",
        },
        columnDefs: this.Config.ColDefs,
        columns: this.Config.ColList,
        filter: this.Config.ShowFilter,
        pageLength: this.Config.PageSize,
        serverSide: this.Config.ProcessOnServer,
        scrollY: this.Config.ViewDesign.Height,
        scrollX: this.Config.ViewDesign.HScroll,
        orderMulti: true, //Multiple Column sorting only works on Client-side (Hold Shift Key for Multi-column sorting)
        oLanguage: {
          sSearch: this.Config.FilterLabel,
          
          //    "sEmptyTable": "No data available in table",
          //    //"sInfo": "Showing 1 to 4 of 4 entries (_START_ to _END_)",
          //    "sInfoEmpty": "No entries to show",
          //    "sInfoFiltered": " - filtering from _MAX_ records",
          //    //"sInfoPostFix": "All records shown are derived from real information.",
          //    "sInfoThousands": "'",
          //    "sLengthMenu": 'Display <select>' +
          //    '<option value="10">100</option>' +
          //    '<option value="20">20</option>' +
          //    '<option value="30">30</option>' +
          //    '<option value="40">40</option>' +
          //    '<option value="50">50</option>' +
          //    '<option value="-1">All</option>' +
          //    '</select> records',
          //    "sLoadingRecords": "Please wait - loading...",
          //    "sProcessing": "Please wait - processing...",
          //    "sZeroRecords": "No records to display"
        },
      });
    };

    this.LoadChildTable = function (vThisObj) {
      debugger;
      if (this.Config.InnerTable.Enabled) {
        var tr = $(vThisObj).closest("tr");
        var row = dt.row(tr);
        var idx = $.inArray(tr.attr("id"), detailRows);

        if (row.child.isShown()) {
          tr.removeClass("details");
          row.child.hide(); //Hide Row Details

          // Remove from the 'open' array
          detailRows.splice(idx, 1);
        } else {
          tr.addClass("details");
          row.child(format(row.data(), this.Config)).show(); //Show Row Details

          // Add to the 'open' array
          if (idx === -1) {
            detailRows.push(tr.attr("id"));
          }
        }

        //Called When Expand Icon is clicked
        function format(data, ConfigJson) {
          var ChildGridJson;

          //Get Data From Child Table
          $.ajax({
            url: ConfigJson.InnerTable.DataUrl,
            data: { action: "loadall", Id: data.Id },
            type: "POST",
            async: false,
            dataType: "json",
            success: function (response) {
              ChildGridJson = response.data;
            },
            error: function (error) {
              console.log("Error:");
              console.log(error);
            },
          });

          return CreateChildTable(ChildGridJson, ConfigJson);
        }

        //Create Child Table
        function CreateChildTable(json_data, ConfigJson) {
          var tbl = document.createElement("table");
          var thead = document.createElement("thead");
          var tbdy = document.createElement("tbody");
          var thr = document.createElement("tr"); //table header row

          tbl.setAttribute("class", ConfigJson.InnerTable.Class);
          tbl.style.width = ConfigJson.InnerTable.Width;
          //tbl.setAttribute('border', '1');

          //Add Column Headers in Child Table
          for (var i in json_data) {
            var val = json_data[i];
            if (i == 0) {
              for (j in val) {
                var sub_key = j;
                if (ConfigJson.InnerTable.ColList.indexOf(sub_key) > -1) {
                  var th = document.createElement("th"); //column
                  var text = document.createTextNode(sub_key); //cell
                  th.appendChild(text);
                  thr.appendChild(th);
                }
              }
            }
          }

          //Add Rows in Child Table
          for (var i in json_data) {
            var key = i;
            var val = json_data[i];
            var tdr = document.createElement("tr"); //table data row
            for (var j in val) {
              var sub_key = j;
              var sub_val = val[j];
              if (ConfigJson.InnerTable.ColList.indexOf(sub_key) > -1) {
                var td = document.createElement("td"); //column
                var text = document.createTextNode(sub_val);
                td.appendChild(text);
                tdr.appendChild(td);
              }
            }
            tbdy.appendChild(tdr);
          }

          thead.appendChild(thr);

          tbl.appendChild(thead);
          tbl.appendChild(tbdy);
          return tbl; //return table to display
        }
      } else {
        alert("Error : InnerTable Flag is set to false");
      }
    };

    this.LoadDataWithGrouping = function () {
      var collapsedGroups = {};
      dt = $("#" + this.Config.Id).DataTable({
        ajax: {
          url: this.Config.DataUrl,
          type: "POST",
          datatype: "json",
        },
        columnDefs: this.Config.ColDefs,
        columns: this.Config.ColList,
        filter: this.Config.ShowFilter,
        pageLength: this.Config.PageSize,
        serverSide: this.Config.ProcessOnServer,
        scrollY: this.Config.ViewDesign.Height,
        scrollX: this.Config.ViewDesign.HScroll,
        orderMulti: true, //Multiple Column sorting only works on Client-side (Hold Shift Key for Multi-column sorting)
        oLanguage: {
          sSearch: this.Config.ViewDesign.FilterLabel,
        },
        order: this.Config.Group.ColOrder,
        rowGroup: {
          dataSrc: this.Config.Group.GroupCol,
          startRender: function (rows, group) {
            var collapsed = !!collapsedGroups[group];

            rows.nodes().each(function (r) {
              r.style.display = collapsed ? "none" : "";
            });

            // Add category name to the <tr>.
            return $("<tr/>")
              .append(
                '<td colspan="' +
                  dt.columns().header().length +
                  '">' +
                  group +
                  " (" +
                  rows.count() +
                  " records)</td>"
              )
              .attr("data-name", group)
              .toggleClass("collapsed", collapsed);
          },
        },
        //, dom: 'lBfrtipHF',
        //buttons: [{
        //    //'copy', 'csv', 'excel', 'pdf', 'print']
        //    extend: 'excel',
        //    exportOptions: {
        //        columns: [1, 2, 3, 4]
        //    }
        //}]
      });

      $("#" + this.Config.Id + " tbody tr.dtrg-start").each(function () {
        var name = $(this).data("name");
        collapsedGroups[name] = !collapsedGroups[name];
      });
      dt.draw(false);

      $("#" + this.Config.Id + " tbody").on(
        "click",
        "tr.dtrg-start",
        function () {
          var name = $(this).data("name");
          collapsedGroups[name] = !collapsedGroups[name];
          dt.draw(false);
        }
      );
    };
  },
};
