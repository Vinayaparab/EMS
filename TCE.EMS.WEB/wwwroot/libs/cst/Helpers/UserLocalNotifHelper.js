class UserLocalNotifHelper {
  constructor() {}

  static SetMsg(vMsg) {
    $.cookie("UserMsg", vMsg, { path: "/" });
  }

  static GetMsg(vMsg) {
    return $.cookie("UserMsg");
  }

  static ClearMsg() {
    $.removeCookie("UserMsg", { path: "/" });
  }

  static ShowMsg() {
    var mMsg = this.GetMsg();

    if (typeof mMsg == "undefined" || mMsg == null || mMsg == "") return;

    try {
      // alert(JSON.parse(mMsg));
    } catch (ex) {}

    AlertHelper.ShowToast(mMsg);
    this.ClearMsg();
  }
}
