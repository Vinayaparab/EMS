var AutoComplete = new (function () {
  this.ParseDropdownCtrl = function (vPlaceHolder, vDropdownCtrlClass) {
    if (
      typeof vPlaceHolder == "undefined" ||
      vPlaceHolder == null ||
      vPlaceHolder == ""
    )
      vPlaceHolder = "Select value from list";

    if (
      typeof vDropdownCtrlClass == "undefined" ||
      vDropdownCtrlClass == null ||
      vDropdownCtrlClass == ""
    )
      vDropdownCtrlClass = ".select2_single";

    $(vDropdownCtrlClass)
      .select2({
        placeholder: vPlaceHolder,
        allowClear: true,
      })
      .change(function () {
        //$(this).valid();    //Added for removing client validation
      });
  };

  this.OnItemSelectTemplate = function (data, container) {
    return data.text;
  };

  function ResultTemplate(state) {
    if (!state.id) {
      return state.text;
    }

    if (state.customprop1 == null) return state.text;

    var mProperties = "";

    mProperties = "<span>" + state.customprop1 + "</span>";

    if (state.customprop2 != null)
      mProperties += ", <span>" + state.customprop2 + "</span>";

    if (state.customprop3 != null)
      mProperties += ", <span>" + state.customprop3 + "</span>";

    if (state.customprop4 != null)
      mProperties += ", <span>" + state.customprop4 + "</span>";

    if (state.customprop5 != null)
      mProperties += ", <span>" + state.customprop5 + "</span>";

    var $state = $(
      '<div style="padding-bottom:5px;border-bottom:solid 1px rgb(230,230,230)">' +
        '<div class="frm-bold">' +
        state.text +
        "</div>" +
        "<div>" +
        mProperties +
        "</div>" +
        "</div>"
    );

    return $state;
  }

  this.Bind = function (vCtrlId, vPath) {
    $(vCtrlId)
      .select2({
        allowClear: true,
        placeholder: $(vCtrlId).attr("placeholder"),
        ajax: {
          url: vPath,
          dataType: "json",
          delay: 250,
          data: function (params) {
            return {
              q: params.term, // search term
              page: params.page,
            };
          },
          processResults: function (data, params) {
            // parse the results into the format expected by Select2
            // since we are using custom formatting functions we do not need to
            // alter the remote JSON data, except to indicate that infinite
            // scrolling can be used

            params.page = params.page || 1;

            return {
              results: data.Results,
              pagination: {
                more: params.page * 30 < data.Total,
              },
            };
          },
          cache: true,
        },
        //escapeMarkup: function (markup) { return markup; }, // let our custom formatter work
        minimumInputLength: 2,
        templateSelection: this.OnItemSelectTemplate,
        templateResult: ResultTemplate /*,
                templateResult: formatRepo, // omitted for brevity, see the source of this page
                templateSelection: formatRepoSelection // omitted for brevity, see the source of this page*/,
      })
      .change(function () {
        //$(this).valid();
      });
  };

  this.ConditionalBind = function (vCtrlId, vPath, vCondition) {
    $(vCtrlId)
      .select2({
        allowClear: true,
        placeholder: $(vCtrlId).attr("placeholder"),
        ajax: {
          url: vPath,
          dataType: "json",
          delay: 250,
          data: function (params) {
            return {
              q: params.term, // search term
              page: params.page,
              condition: vCondition,
            };
          },
          processResults: function (data, params) {
            // parse the results into the format expected by Select2
            // since we are using custom formatting functions we do not need to
            // alter the remote JSON data, except to indicate that infinite
            // scrolling can be used

            params.page = params.page || 1;

            return {
              results: data.Results,
              pagination: {
                more: params.page * 30 < data.Total,
              },
            };
          },
          cache: true,
        },
        //escapeMarkup: function (markup) { return markup; }, // let our custom formatter work
        minimumInputLength: 2,
        templateSelection: this.OnItemSelectTemplate,
        templateResult: ResultTemplate /*,
                templateResult: formatRepo, // omitted for brevity, see the source of this page
                templateSelection: formatRepoSelection // omitted for brevity, see the source of this page*/,
      })
      .change(function () {
        //$(this).valid();
      });
  };
})();

function ErrorLog(vData, ErrorDivId, vshowAlert) {
  try {
    var mErrorId = "";

    if (
      typeof ErrorDivId == "undefined" ||
      ErrorDivId == null ||
      ErrorDivId == ""
    )
      mErrorId = "divError";
    else {
      mErrorId = ErrorDivId;
    }

    $("#" + mErrorId).show();

    DisplayErrors(vData.Errors, mErrorId);

    if (vshowAlert == false) {
      AlertHelper.ShowErrorAlert(
        "There are errors found. Please refer to the error list below"
      );
    }
  } catch (ex) {
    //alert(ex)
  }
}

function DisplayErrors(errors, ErrorDivId) {
  try {
    if (
      typeof ErrorDivId == "undefined" ||
      ErrorDivId == null ||
      ErrorDivId == ""
    )
      mErrorId = "divError";
    else {
      mErrorId = ErrorDivId;
    }

    $("#" + mErrorId).text("");

    if (errors.length > 0) {
      $("#" + mErrorId).append(
        "<div id='" +
          mErrorId +
          "List' class='uk-alert uk-alert-danger validation-summary-errors' data-valmsg-summary='true'>" +
          "<span class='h4 text-danger'>The Following errors were encountered on this page:</span></div>"
      );

      var mList = $("<ul></ul>");

      for (var i = 0; i < errors.length; i++) {
        if (i == 0) {
        }

        mList.append(
          '<li class="text-danger1 h5">' + errors[i].Value + "</li>"
        );
      }
      $("#" + mErrorId + "List").append(mList);
    }
  } catch (ex) {
    //alert(ex);
  }
}

var PageObj = function ($scope,$uibModal,$rs, $timeout, $route, $routeParams, $location, $sce, $templateCache, $filter, $q, $http, $compile, blockUI) {
  this.$rs = $rs;
  this.$scope = $scope;
  this.$timeout = $timeout;
  this.$uibModal = $uibModal;
  this.$route = $route;
  this.$routeParams = $routeParams;
  this.$location = $location;
  this.$sce = $sce;
  this.$templateCache = $templateCache;
  this.$filter = $filter;
  this.$q = $q;
  this.$http = $http;
  this.$compile = $compile;
  this.blockUI = blockUI;

  //Initialize
  this.Init = function () {
      var PageObj = this;

      //Add the below line to stop caching the page.
      //$templateCache.remove($route.current.templateUrl);

      _CurrPageCtrlScope = $scope;

      $scope.modalAnim = "modal3DFlipVertical";

      //$scope.$on("$destroy", function (event) {
      //    PageObj = null;
      //    //$timeout.cancel(timer);
      //});
  }

  //Bind Events related to Data Entry, etc. Forms
  this.BindFormEvents = function () {
      //Bind Page Validators
      $.validator.unobtrusive.parse($('form'));

      $("form button[type=submit]").click(function () {
          $("button[type=submit]", $(this).parents("form")).removeAttr("clicked");
          $(this).attr("clicked", "true");
      });

      //Common Action on form submit
      $('form').submit(function () {
          
          if (!$("button[type=submit][clicked=true]").hasClass("cancel")) {
              if ($(this).valid()) {
                  blockUI.start("Processing your request, please wait...");
              }
          }
          else {
              blockUI.start("Processing your request, please wait...");
          }
      });

      $.validator.setDefaults({
          highlight: function (element) {
              $(element).closest("div").addClass("has-error");
          },
          unhighlight: function (element) {
              $(element).closest("div").removeClass("has-error");
          }
      });
  }

  //Parse Dropdown Style
  this.ParseDropdownCtrl = function (vPlaceHolder, vDropdownCtrlClass) {
      if (typeof (vPlaceHolder) == "undefined" || vPlaceHolder == null || vPlaceHolder == "")
          vPlaceHolder = "Select value from list";

      if (typeof (vDropdownCtrlClass) == "undefined" || vDropdownCtrlClass == null || vDropdownCtrlClass == "")
          vDropdownCtrlClass = ".select2_single";

      $(vDropdownCtrlClass).select2({
          placeholder: vPlaceHolder,
          allowClear: true
      }).change(function () {
          //$(this).valid();
      });
  }

  //Parse Date Picker
  this.ParseDatePickerCtrl = function () {
      $('.InputdatepickerDate').datepicker({
          format: 'dd/M/yyyy',
          todayHighlight: true,
          autoclose: true,
          pickerPosition: 'bottom-left',
      }).on('changeDate', function (ev) {
      //    $(this).valid();
      });
  }

  //Parse Time Picker
  this.ParseTimePickerCtrl = function () {
      $('.timepicker').timepicker({
          minuteStep: 1,
          showSeconds: true,
          showMeridian: false,
          disableFocus: false,
          showWidget: true
      }).focus(function () {
          $(this).next().trigger('click');
      }).change(function () {
          $(this).valid();
      });
  }

  //Fires when there is an error executing the action.
  this.ShowError = function (vData, ErrorDivId) {
      try {

          var mErrorId = "";

          if (typeof (ErrorDivId) == "undefined" || ErrorDivId == null || ErrorDivId == "")
              mErrorId = "divError";
          else {
              mErrorId = ErrorDivId;
          }

          $("#" + mErrorId).show();

          DisplayErrors(vData.Errors, mErrorId);

          blockUI.stop();
          $scope.$applyAsync(function () { blockUI.stop(); });

          bootbox.alert($("#" + mErrorId).html());
      } catch (ex) {
          alert(ex)
      }
  }

  //Fires when there is an error executing the action.
  this.ShowValidationSummary = function () {
      try {
          $('.validation-summary-errors').hide();
          bootbox.alert($('.validation-summary-errors').html());
      } catch (ex) {
          alert(ex)
      }
  }

  //Common Action on Form Exit
  this.Exit = function (vURL, vMsg) {
      if (typeof (vMsg) == "undefined" || vMsg == null || vMsg == "")
          vMsg = "You are currently in edit mode. Are you sure, you want to exit?";

      if ($("#hiddIsEditMode").val() == "Y") {
          var mPageObj = this;

          bootbox.confirm(vMsg, function (result) {
              if (result) {
                  mPageObj.RedirectToURL(vURL);
              }
          });
      }
      else {
          this.RedirectToURL(vURL);
      }
  }

  this.BindValidatorsForDynamicFields = function () {
      $('form').data('validator', null);
      $.validator.unobtrusive.parse($('form'));
  }

  this.RedirectToURL = function (vURL, vIsNewTab) {
      var mPageObj = this;

      //For Single Page App
      //$scope.$applyAsync(function () { mPageObj.$location.url(vURL); });

      if (vIsNewTab == "NewTab") {
          window.open(_RootURL + vURL, '_blank');
      }
      else {
          //For Normal App
          window.location.href = _RootURL + vURL;
      }
     
  }

  this.OpenModal = function (vURL) {
      $modal.open({
          templateUrl: vURL,
          size: "lg",
          controller: function ($scope) {
              $scope.modalClose = function () {
                  $scope.$close()
              }
          },
          resolve: {
          },
          windowClass: $scope.modalAnim
      })
  }

}

