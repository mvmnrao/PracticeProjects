var Person = function (name) {
    //defaults
    this._age = 2;
    this._name = name;

    this.initialize = function (name, age) {
        this._name = name || this._name;
        this._age = age || this._age;
    };

  

    this.initialize();
};

    //getters and setters
Person.prototype.getName = function () { return this._name; };
Person.prototype.setName = function (name) {this._name = name; };

    //public methods
Person.prototype.addBirthday = function () { this._age++; };
Person.prototype.toString = function () { return 'My name is ' + this.getName() + ' and I am ' + this._age + ' years old.'; }
