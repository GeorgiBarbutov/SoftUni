function isSymmetric(arr) {
    if (!Array.isArray(arr))
        return false; // Non-arrays are non-symmetric
    let reversed = arr.slice(0).reverse(); // Clone and reverse
    let equal = (JSON.stringify(arr) == JSON.stringify(reversed));
    return equal;
}

let assert = require("chai").assert;

describe("CheckForSymmetry", function(){
    it("Takes an array as argument", function(){
        assert.equal(isSymmetric("aa"), false);
    });
    it("Returns true if array is symmetric", function(){
        assert.equal(isSymmetric([1, 2, 3, 3, 2, 1]), true);
    });
    it("Returns false if array is not symmetric", function(){
        assert.equal(isSymmetric([1, 2, 2, 3, 3, 2, 1]), false);
    });
    it("Returns false if array is not symmetric and one element is of different type", function(){
        assert.equal(isSymmetric([1, "2", 2, 3, 3, 2, 1]), false);
    });
    it("Returns false if array is symmetric and one element is of different type", function(){
        assert.equal(isSymmetric([1, "2", 3, 3, 2, 1]), false);
    });
});