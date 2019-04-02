function rgbToHexColor(red, green, blue) {
    if (!Number.isInteger(red) || (red < 0) || (red > 255))
        return undefined; // Red value is invalid
    if (!Number.isInteger(green) || (green < 0) || (green > 255))
        return undefined; // Green value is invalid
    if (!Number.isInteger(blue) || (blue < 0) || (blue > 255))
        return undefined; // Blue value is invalid
    return "#" +
        ("0" + red.toString(16).toUpperCase()).slice(-2) +
        ("0" + green.toString(16).toUpperCase()).slice(-2) +
        ("0" + blue.toString(16).toUpperCase()).slice(-2);
}

let assert = require("chai").assert;

describe("something", function(){
    it("Returns undefined if red is not a number", function(){
        assert.equal(rgbToHexColor("1", 2, 3), undefined);
    });
    it("Returns undefined if green is not a number", function(){
        assert.equal(rgbToHexColor(1, "2", 3), undefined);
    });
    it("Returns undefined if blue is not a number", function(){
        assert.equal(rgbToHexColor(1, 2, "3"), undefined);
    });
    it("Returns undefined if red is less than zero", function(){
        assert.equal(rgbToHexColor(-1, 2, 3), undefined);
    });
    it("Returns undefined if green is less than zero", function(){
        assert.equal(rgbToHexColor(1, -2, 3), undefined);
    });
    it("Returns undefined if blue is less than zero", function(){
        assert.equal(rgbToHexColor(1, 2, -3), undefined);
    });
    it("Returns undefined if red is more than 255", function(){
        assert.equal(rgbToHexColor(260, 2, 3), undefined);
    });
    it("Returns undefined if green is more than 255", function(){
        assert.equal(rgbToHexColor(1, 290, 3), undefined);
    });
    it("Returns undefined if blue is more than 255", function(){
        assert.equal(rgbToHexColor(1, 2, 300), undefined);
    });
    it("Returns #4286F4", function(){
        assert.equal(rgbToHexColor(66, 134, 244), "#4286F4");
    });
    it("Returns correct if red is 255", function(){
        assert.equal(rgbToHexColor(255, 1, 1), '#FF0101');
    });
    it("Returns correct if green is 255", function(){
        assert.equal(rgbToHexColor(1, 255, 1), '#01FF01');
    });
    it("Returns correct if blue is 255", function(){
        assert.equal(rgbToHexColor(1, 1, 255), '#0101FF');
    });
    it("Returns correct if red is 0", function(){
        assert.equal(rgbToHexColor(0, 1, 1), '#000101');
    });
    it("Returns correct if green is 0", function(){
        assert.equal(rgbToHexColor(1, 0, 1), '#010001');
    });
    it("Returns correct if blue is 0", function(){
        assert.equal(rgbToHexColor(1, 1, 0), '#010100');
    });
});