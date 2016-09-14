//home-index.js
var module = angular.module("homeIndex", []);

module.config(function ($routeProvider) {
  $routeProvider.when("/", {
    controller: "topicsController",
    templateUrl: "/templates/topicsView.html"
  });

  $routeProvider.when("/newmessage", {
    controller: "newTopicController",
    templateUrl: "/templates/newTopicView.html"
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

function newTopicController($scope, $http, $window) {
  $scope.newTopic = {};

  $scope.save = function () {
    alert($scope.newTopic.title);
  };
}

