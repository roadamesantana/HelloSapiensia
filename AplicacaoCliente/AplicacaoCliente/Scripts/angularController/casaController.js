var testApp = angular
.module("app", [])
.controller("casaController", function ($scope, $http) {
    $http.get('http://localhost:53917/api/funcoes').then(function (response) {
        $scope.listaCasasFuncoes = response.data;
    });
});