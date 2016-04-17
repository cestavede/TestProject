var LandingPageController = function ($scope, $http) {
    $scope.models = {
        helloAngular: 'I work!'
    };

    var onError = function (reason) {
        $scope.error = "*Could not find such a Company";
    }

    var onRequestComplete = function (response) {
        $scope.companies = response.data;
    }

    $scope.search = function (companyName) {
        $http.get("http://localhost:1568/api/Company/search/" + companyName)
        .then(onRequestComplete, onError);
    }

    $scope.companyName = "startup";
    
}

// The $inject property of every controller (and pretty much every other type of object in Angular) 
// needs to be a string array equal to the controllers arguments, only as strings
LandingPageController.$inject = ['$scope','$http'];