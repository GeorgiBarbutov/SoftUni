function spiralMatrix(n, m) {
    let result = [];
    let number = 1;
    let lastColIndex = m - 1;
    let lastRowIndex = n - 1;

    for (let i = 0; i < n; i++) {
        result[i] = [];
    }

    let cycle = 0;

    do{
        for (let i = cycle; i < m - cycle; i++) {
            result[cycle][i] = number;
            number += 1;
        }
        for (let i = 1 + cycle; i < n - cycle; i++) {
            result[i][lastColIndex - cycle] = number;
            number += 1;
        }
        for (let i = lastColIndex - 1 - cycle; i >= 0 + cycle; i--){
            result[lastRowIndex - cycle][i] = number;
            number += 1;
        }
        for (let i = lastRowIndex - 1 - cycle; i >= 1 + cycle; i--){
            result[i][cycle] = number;
            number += 1;
        }
        cycle += 1;
    } while(cycle !== Math.ceil(Math.min(n, m) / 2));
    

    for (let i = 0; i < result.length; i++) {
        console.log(result[i].join(" "));
    }
}

spiralMatrix(7, 3);