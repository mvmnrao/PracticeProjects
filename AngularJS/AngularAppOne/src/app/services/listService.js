angular.module("notesApp")
.factory("listService", [function(){
    var items = [
        { id: 1, name: 'item 1' },
        { id: 2, name: 'item 2' }];

    return {
        list: function(){
            return items;
        },
        add: function(item){
            items.push(item);
        }
    };
}]);