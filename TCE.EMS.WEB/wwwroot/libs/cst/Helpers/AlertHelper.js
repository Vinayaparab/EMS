class AlertHelper {
  constructor() {}

  static ShowToast(vMsg) {
    if (vMsg == null || vMsg == "") vMsg = "Action Completed Successfully";

    Swal.fire({
      position: "top-end",
      icon: "success",
      title: vMsg,
      showConfirmButton: false,
      timer: 1500,
    });
  }

  static ShowErrorAlert(vMsg) {
    Swal.fire({
      icon: "error",
      title: "Oops...",
      text: vMsg,
    });
  }

  static ShowAlert(vMsg) {
    Swal.fire({
      icon: "success",
      title: "Message",
      text: vMsg,
    });
  }
}
