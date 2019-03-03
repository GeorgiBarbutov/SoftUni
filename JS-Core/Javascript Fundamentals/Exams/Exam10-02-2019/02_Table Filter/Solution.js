function tableFilter(matrix, commandInput){ //80%
    let commandArguments = commandInput.split(" ");

    let command = commandArguments[0];

    let result = [];
    if(command === "hide"){
        let header = commandArguments[1];

        let indexToHide = matrix[0].indexOf(header);

        for (let i = 0; i < matrix.length; i++) {
            if(indexToHide != -1){
                matrix[i].splice(indexToHide,1);
            }
        }
        result = matrix;
    } else if(command === "filter"){
        result[0] = matrix[0];
        

        let headerToSearchFor = commandArguments[1];
        let valueToSearchFor = commandArguments[2];

        let isNumber = false;

        if(!isNaN(valueToSearchFor)){
            isNumber = true;
        }

        let indexOfHeader = matrix[0].indexOf(headerToSearchFor);

        let a = matrix.filter((row, index) => index !== 0 && ((row[indexOfHeader] === valueToSearchFor && !isNumber) ||(+row[indexOfHeader] === +valueToSearchFor && isNumber)))[0];
        
        if(a != null){
            result[1] =[];

            a.map((value, index) => result[1][index] = value);
        }
    } else if(command === "sort"){
        result[0] = matrix[0];

        let header = commandArguments[1];

        let indexOfHeader = matrix[0].indexOf(header);

        matrix.filter((row, index) => index !== 0)
            .sort((a, b) => a[indexOfHeader].localeCompare(b[indexOfHeader]))
            .map((row, index) => result[index + 1] = row);
    }

    for (let i = 0; i < result.length; i++) {
        console.log(result[i].join(" | "));
    }
}

tableFilter([['A', 'B', 'C', 'D'],
['a', 'a', 'a', 'a'],
['b', 'c', 'a', 'b'],
['c', 'a', 'c', 'c']],
'filter D d'
);