let a = (function vectorMath(){
    return {
        add: (vec1, vec2) => [vec1[0] + vec2[0], vec1[1] + vec2[1]],
        multiply: (vec, multiplier) => [vec[0] * multiplier, vec[1] * multiplier],
        length: (vec) => Math.sqrt((vec[0] * vec[0]) + (vec[1] * vec[1])),
        dot: (vec1, vec2) => (vec1[0] * vec1[1]) + (vec2[0] * vec2[1]),
        cross: (vec1, vec2) => (vec1[0] * vec2[1]) - (vec2[0] * vec1[1])
    };
})()

console.log(a.dot([2, 3], [2, -1]));

