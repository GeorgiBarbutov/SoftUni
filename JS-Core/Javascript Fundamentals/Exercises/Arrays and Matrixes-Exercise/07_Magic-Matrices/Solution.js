function isMagicMatrix(matrix) {
    let isMagical = true;

    let sum = 0;

    for (let i = 0; i < matrix.length; i++) {
        let rowSum = 0;

        for (let j = 0; j < matrix[i].length; j++) {
            rowSum += matrix[i][j];
            
            if(i === 0) {
                sum += matrix[i][j];
            }
        }

        if(rowSum !== sum) {
            isMagical = false;
            break;
        }
    }

    for (let j = 0; j < matrix[0].length; j++) {
        let colSum = 0;

        for (let i = 0; i < matrix.length; i++) {
            colSum += matrix[i][j];
        }

        if(colSum !== sum) {
            isMagical = false;
            break;
        }
    }
    
    console.log(isMagical);
}