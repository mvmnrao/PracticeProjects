angular.module('notesApp', [])
    .controller('mainCtrl', ['$scope', function ($scope) {
        $scope.a = 1;
        $scope.b = 2;
        $scope.names = ['One', 'Two', 'three'];

        var self = this;
        self.message = 'Hello ';
        self.changeMessage = function () {
            self.message = 'Goodbye ';
        };
        var goodbyeMsg = 'Goodbye ';

        self.notes = [
            { id: 1, title: 'First Note', done: false, assignee: 'Manik' },
            { id: 2, title: 'Second Note', done: false },
            { id: 3, title: 'Third Note has been completed', done: true },
            { id: 4, title: 'Forth Note', done: false, assignee: 'Bryan' }
        ];

        self.notes1 = {
            Manik: { id: 1, title: 'First Note', done: false, assignee: 'Manik' },
            ramesh: { id: 2, title: 'Second Note', done: false },
            bryan: { id: 3, title: 'Third Note', done: false, assignee: 'Bryan' }
        };

        self.notes2 = angular.copy(self.notes);
        self.notes3 = angular.copy(self.notes);

        self.changeNotes = function () {
            self.notes = [
                { id: 1, title: 'First Note is done.', done: true, assignee: 'Manik' },
                { id: 2, title: 'Second Note', done: false },
                { id: 3, title: 'Third Note has been completed', done: true },
                { id: 4, title: 'Forth Note', done: false, assignee: 'Bryan' }
            ];
            self.notes2 = angular.copy(self.notes);
            self.notes3 = angular.copy(self.notes);
        };

        self.countries = [
            { label: 'INDIA', id: 1 },
            { label: 'USA', id: 2 },
            { label: 'Russia', id: 3 }
        ];

        self.selectedCountryId = 1;
        self.selectedCountry = self.countries[2];

        self.getNoteClass = function (status) {
            return {
                done: status,
                pending: !status
            };
        };

        self.getClassWithNgHelper = function (first, middle, last, even, odd) {
            return {
                first: first,
                middle: middle,
                last: last,
                even: even,
                odd: odd
            };
        };

        self.tab = 'two';
        self.turnSwitch = function(sw){
            self.tab = sw;
        };        

        self.login = function () {
            alert("Username:: " + self.user.username + " |::| Password:: " + self.user.password);
        };
        
    }])
    .filter('yesOrNo', function () {
        return function (input) {
            return input ? 'Yes' : 'No';
        }
    });