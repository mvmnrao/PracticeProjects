angular.module("notesApp")
.controller("firstController", ["listService", function(listService){
    var self = this;
    self.items = function(){
        return listService.list();
    };
    //self.items = [{id: 1, name: 'item 1'}];

    self.add = function(){
        listService.add({
            id: self.items().length + 1,
            name: 'item ' + (self.items().length + 1)
        });
    };
}]);