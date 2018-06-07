describe('Person Test', function(){
    var testPerson;
    beforeEach(function(){
        testPerson = new Person('Manik');
    });
    afterEach(function(){
        testPerson = undefined;
    });

    it('Should test name', function(){
        //var p = new Person('Manik');
        expect(testPerson.getName()).toBe('Manik');
    });

    it('calls the fake getName() with call back function', function(){
        spyOn(testPerson.getName)
    });
});