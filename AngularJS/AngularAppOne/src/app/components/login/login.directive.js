angular.module('notesApp')
.directive('loginDir', function(){
        return {
            restrict: 'E',
            scope: {
                testMessage: "=",
            },
            templateUrl: '/src/app/components/login/login.html',
            controller: "loginCtrl"
        };
});