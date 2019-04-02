function createCalculator() {
    let value = 0;
    return {
        add: function(num) { value += Number(num); },
        subtract: function(num) { value -= Number(num); },
        get: function() { return value; }
    }
}

let assert = require("chai").assert;

describe("Adding and Subtracting", function(){
    it("returns a object containing add subtract and get functions", function(){
        let keys = Object.keys(createCalculator());

        assert.equal(keys[0], "add");
        assert.equal(keys[1], "subtract");
        assert.equal(keys[2], "get");
    })
    it("get returns the correct number", function(){
        let calculator = createCalculator();

        assert.equal(calculator.get(), 0);
    })
    it("adding works with numbers", function(){
        let calculator = createCalculator();

        calculator.add(1);
        assert.equal(calculator.get(), 1);

        calculator.add(2);
        assert.equal(calculator.get(), 3);
        
        calculator.add(3);
        assert.equal(calculator.get(), 6);
    })
    it("adding works with strings", function(){
        let calculator = createCalculator();

        calculator.add("1");
        assert.equal(calculator.get(), 1);

        calculator.add("2");
        assert.equal(calculator.get(), 3);
        
        calculator.add("3");
        assert.equal(calculator.get(), 6);
    })
    it("subtraction works with numbers", function(){
        let calculator = createCalculator();

        calculator.subtract(1);
        assert.equal(calculator.get(), -1);

        calculator.subtract(2);
        assert.equal(calculator.get(), -3);
        
        calculator.subtract(3);
        assert.equal(calculator.get(), -6);
    })
    it("subtraction works with strings", function(){
        let calculator = createCalculator();

        calculator.subtract("1");
        assert.equal(calculator.get(), -1);

        calculator.subtract("2");
        assert.equal(calculator.get(), -3);
        
        calculator.subtract("3");
        assert.equal(calculator.get(), -6);
    })
})