function isOddOrEven(string) {
    if (typeof(string) !== 'string') {
        return undefined;
    }
    if (string.length % 2 === 0) {
        return "even";
    }

    return "odd";
}

let assert = require("chai").assert;

describe("Even or Odd", function(){
    it("returns undefined if passed argument is not a string", function(){
        let result = isOddOrEven(1);

        assert.equal(result, undefined);
    })
    it("returns even", function(){
        let result = isOddOrEven("aaaaaa");

        assert.equal(result, "even");
    })
    it("returns odd", function(){
        let result = isOddOrEven("aaaaa");

        assert.equal(result, "odd");
    })
})