class FormHelper {
  FormId = null;
  $FormObj = null;

  constructor(vFormId) {
    if (typeof vFormId !== "undefined") {
      this.FormId = vFormId;
      this.$FormObj = $("#" + vFormId);
    }
  }

  // Adding a method to the constructor
  Init() {
    if (this.FormId != null) {
      this.$FormObj.find(".xform-loader").hide();
      $.validator.unobtrusive.parse(this.$FormObj);
    } else {
      $(".xform-loader").hide();
    }
  }

  ShowActionLoader() {
    if (this.FormId != null) {
      this.$FormObj.find(".xform-actions").hide();
      this.$FormObj.find(".xform-loader").show();
      this.$FormObj.find(".xform-errors").text("");
      this.$FormObj.find(".xform-errors").hide();
    } else {
      $(".xform-actions").hide();
      $(".xform-loader").show();
      $(".xform-errors").text("");
      $(".xform-errors").hide();
    }
  }

  ShowError(vReturnReceipt) {
    console.log(JSON.stringify(vReturnReceipt));

    var xFormErrorsObj = null;

    if (this.FormId != null) {
      xFormErrorsObj = this.$FormObj.find(".xform-errors");
    } else {
      xFormErrorsObj = $(".xform-errors");
    }

    xFormErrorsObj.show();

    if (
      vReturnReceipt.ErrorList != null &&
      vReturnReceipt.ErrorList.length > 0
    ) {
      var $ul = $("<ul></ul>");
      $.each(vReturnReceipt.ErrorList, function (i, item) {
        $ul.append("<li>" + item.Value + "</li>");
      });

      xFormErrorsObj
        .append("<div>Following errors occured!!</div>")
        .append($ul);
    } else {
      xFormErrorsObj.text(vReturnReceipt.Msg);
    }

    if (this.FormId != null) {
      this.$FormObj.find(".xform-actions").show();
      this.$FormObj.find(".xform-loader").hide();
    } else {
      $(".xform-actions").show();
      $(".xform-loader").hide();
    }

    AlertHelper.ShowErrorAlert(
      "There seems to be errors found while performing the action. Please review error section by scrolling on top."
    );
  }

  ParseResponse(xhr) {
    if (xhr.status == 200) {
      return JSON.parse(xhr.responseText);
    } else {
      return {
        IsSuccess: false,
        ErrorList: [{ Value: xhr.responseText }],
      };
    }
  }

  NotifyUser(vMsg) {
    if (vMsg == null || vMsg == "") vMsg = "Record Saved Successfully";

    UserLocalNotifHelper.SetMsg(vMsg);
  }
}
