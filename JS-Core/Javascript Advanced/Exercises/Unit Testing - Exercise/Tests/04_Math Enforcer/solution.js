let mathEnforcer = {
    addFive: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },
    sum: function (num1, num2) {
        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};

mathEnforcer.addFive("a");

let assert = require("chai").assert;

describe("mathEnforcer", function(){
    describe("addFive", function(){
        it("returns undefined if passed argument is not a number", function(){
            let result = mathEnforcer.addFive("a");
        
            assert.equal(result, undefined);
        });
        it("works with positive numbers", function(){
            let result = mathEnforcer.addFive(5);
        
            assert.equal(result, 10);
        });
        it("works with negative numbers", function(){
            let result = mathEnforcer.addFive(-10);
        
            assert.equal(result, -5);
        });
        it("works with floating point numbers", function(){
            let result = mathEnforcer.addFive(2.3);
        
            assert.equal(result, 7.3);
        });
    });
    describe("subtract ten", function(){
        it("returns undefined if passed argument is not a number", function(){
            let result = mathEnforcer.subtractTen("a");
        
            assert.equal(result, undefined);
        });
        it("works with positive numbers", function(){
            let result = mathEnforcer.subtractTen(5);
        
            assert.equal(result, -5);
        });
        it("works with negative numbers", function(){
            let result = mathEnforcer.subtractTen(-10);
        
            assert.equal(result, -20);
        });
        it("works with floating point numbers", function(){
            let result = mathEnforcer.subtractTen(2.3);
        
            assert.equal(result, -7.7);
        });
    });
    describe("sum", function(){
        it("returns undefined if passed arguments are not numbers", function(){
            let result = mathEnforcer.sum("a", 1);
        
            assert.equal(result, undefined);

            result = mathEnforcer.sum("a", "b");
        
            assert.equal(result, undefined);

            result = mathEnforcer.sum(1, "b");
        
            assert.equal(result, undefined);
        });
        it("works with positive numbers", function(){
            let result = mathEnforcer.sum(5, 10);
        
            assert.equal(result, 15);
        });
        it("works with negative numbers", function(){
            let result = mathEnforcer.sum(-3, -5);
        
            assert.equal(result, -8);
        });
        it("works with floating point numbers", function(){
            let result = mathEnforcer.sum(2.3, 1.6);
        
            assert.equal(result, 3.9);
        });
    });
});
