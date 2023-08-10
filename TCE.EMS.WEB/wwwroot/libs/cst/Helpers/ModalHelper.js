class ModalHelper {
  $uibModalObj = null;

  constructor($uibModalObj) {
    this.$uibModalObj = $uibModalObj;
  }

  // Adding a method to the constructor
  Open(vURL) {
    debugger;
    var modalInstance = this.$uibModalObj.open({
      templateUrl: vURL + "?" + QueryString.GetRandomStr(),
      size: "xl",
      windowClass: "show",
      backdropClass: "show",
      backdrop: "static",
      keyboard: false,
      controller: function ($scope) {
        $scope.CloseModal = function () {
          $scope.$close();
        };
      },
    });
  }
}
