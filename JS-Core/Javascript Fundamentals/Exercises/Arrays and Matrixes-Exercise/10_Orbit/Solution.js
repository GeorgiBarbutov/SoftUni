function orbit(inputArray) {
    let width = inputArray[0];
    let height = inputArray[1];
    let x = inputArray[2];
    let y = inputArray[3];

    let space = [];

    for (let i = 0; i < height; i++) {
        space[i] = []
    }

    for (let i = 0; i < height; i++) {
        for (let j = 0; j < width; j++) {
            let rowDifference = Math.abs(i - x);
            let colDifference = Math.abs(j - y);

            let maxDifference = Math.max(rowDifference, colDifference);

            space[i][j] = maxDifference + 1;
        }     
          
        console.log(space[i].join(" "));
    }
}