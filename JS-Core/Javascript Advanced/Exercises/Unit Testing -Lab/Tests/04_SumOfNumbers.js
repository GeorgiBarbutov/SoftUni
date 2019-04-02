function sum(arr) {
    let sum = 0;
    for (num of arr)
        sum += Number(num);
    return sum;
}

const assert = require("chai").assert;

describe("Sum of Numbers", function(){
    it("returns correct result", function(){
        let result = sum([1, 2, 3, 4, 5]);

        assert.equal(result, 15);
    });
    it("throws an error when not given an array", function(){
        assert.throw(sum, "arr is not iterable");
    })
    it("does not throw an error when given an array", function(){
        let result = sum([0, 0, 0, 0, 0]);

        assert.equal(result, 0);
    })
})