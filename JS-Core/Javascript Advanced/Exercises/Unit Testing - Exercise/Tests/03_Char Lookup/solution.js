function lookupChar(string, index) {
    if (typeof(string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }
    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}

let assert = require("chai").assert;

describe("lookUpCgar", function(){
    it("returns undefined if first argument is not a string", function(){
        let result = lookupChar(1, 1);

        assert.equal(result, undefined);
    })
    it("returns undefined if second argument is a floating point number", function(){
        let result = lookupChar("sassa", 1.43);

        assert.equal(result, undefined);
    })
    it("returns undefined if second argument is not a number", function(){
        let result = lookupChar("sasa", "sdsd");

        assert.equal(result, undefined);
    })
    it("returns Incorrect index if index is more or less or equal to the lenght of the string", function(){
        let result = lookupChar("aaa", -1);

        assert.equal(result, "Incorrect index");

        result = lookupChar("aaa", 3);

        assert.equal(result, "Incorrect index");

        result = lookupChar("aaa", 55);

        assert.equal(result, "Incorrect index");
    })
    it("returns correct number at index", function(){
        let result = lookupChar("abc", 2);

        assert.equal(result, "c");
    })
})