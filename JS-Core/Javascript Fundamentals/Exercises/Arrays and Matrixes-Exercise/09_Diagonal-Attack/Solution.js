function diagonalAttack(inputArray) {
    let matrix = [];

    for (let i = 0; i < inputArray.length; i++) {
        matrix[i] = []
        for (let j = 0; j < inputArray[i].split(" ").length; j++) {
            matrix[i][j] = inputArray[i].split(" ")[j];
        }
    }

    let mainDiagonalSum = 0;
    let secondaryDiagonalSum = 0;

    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix[i].length; j++) {
            if(i === j){
                mainDiagonalSum += Number(matrix[i][j]);
            }
            if(i + j === matrix.length - 1){
                secondaryDiagonalSum += Number(matrix[i][j]);
            }
        }
    }

    let sumsAreEqual = mainDiagonalSum === secondaryDiagonalSum;

    if(sumsAreEqual) {
        for (let i = 0; i < matrix.length; i++) {
            for (let j = 0; j < matrix[i].length; j++) {
                if(i !== j && i + j !== matrix.length - 1) {
                    matrix[i][j] = Number(mainDiagonalSum);
                }
            }

            console.log(matrix[i].join(" "));
        }   
    } else {
        for (let i = 0; i < matrix.length; i++) {
            console.log(matrix[i].join(" "));
        }
    }
}