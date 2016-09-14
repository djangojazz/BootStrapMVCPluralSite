//home-index.js
var module = angular.module("homeIndex", []);

module.config(function ($routeProvider) {
  $routeProvider.when("/", {
    controller: "topicsController",
    templateUrl: "/templates/topicsView.html"
  });

  $routeProvider.otherwise({ redirectTo: "/" });
});

function topicsController($scope, $http) {
  $scope.data = [];
  $scope.isBusy = true;

  $http.get("/api/v1/topics?includeReplies=true")
  .then(function (result) {
    //Successful
    angular.copy(result.data, $scope.data)
  },
  function () {
    //Error
    alert("could not load topics")
  })
  .then(function () {
    $scope.isBusy = false;
  });
}