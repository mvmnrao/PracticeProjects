angular.module("notesApp")
.controller("secondController", ["listService", function(listService){
    var self = this;

    self.items = function(){
        return listService.list();
    };
}]);