angular.module('notesApp')
.controller('loginCtrl', ['$scope', function($scope){
    var self = this;

    self.username = "one";

    self.change = function(){
        self.username = "changed";
        self.password = "password";
        //alert(this.testMessage);
    };

    self.submit = function(){
        console.log('User clicked submit with ', self.username, self.password);
    };
}]);