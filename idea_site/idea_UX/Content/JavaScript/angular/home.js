/*AngularJS document*/

var app = angular.module('myStore', ['ngRoute', 'ngRoutesConfig', 'oitozero.ngSweetAlert']);

app.controller('homeCtrl', ['$scope', '$http', 'SweetAlert', function ($scope, $http, SweetAlert) {
    $scope.msg = "Hello Angular Routesss";

    $scope.addUser = function (user) {

        SweetAlert.swal(
       {
           title: "",
           text: "Please wait.",
           imageUrl: "content/plugins/sweetalert/loading_spinner.gif",
           showConfirmButton: false
       });

        //ajax call to server
        $http({
            url: "/Registration/Register",
            method: "POST",
            data: {'newUser':'Hari Om'},
        })
        .then(function (data) {
            if (data.status === 200 && data.data=="Success") {
                SweetAlert.swal({ title: "", text: data.data.toString(), });
            }
        })

    }
}])