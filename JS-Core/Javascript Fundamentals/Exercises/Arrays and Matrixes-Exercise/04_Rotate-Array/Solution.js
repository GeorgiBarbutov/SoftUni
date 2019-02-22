function rotate(input) {
    let rotationsCount = Number(input[input.length - 1]);

    let jump = rotationsCount % (input.length - 1);

    let result = input.filter((val, index, arr) => index !== arr.length - 1);

    for (let i = 0; i < result.length; i++) {
        result[(i + jump) % result.length] = input[i];
    }

    console.log(result.join(" "));
}

rotate(['1', '2', '3', '4', '15']);