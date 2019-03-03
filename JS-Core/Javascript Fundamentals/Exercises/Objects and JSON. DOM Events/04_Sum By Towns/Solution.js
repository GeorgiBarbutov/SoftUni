function sumByTowns(inputArray) {
    let result = {};
    
    for (let i = 0; i < inputArray.length; i += 2) {
        if(Object.keys(result).includes(inputArray[i])){
            result[inputArray[i]] += Number(inputArray[i + 1]);
        } else {
            result[inputArray[i]] = Number(inputArray[i + 1]);
        }
    }

    console.log(JSON.stringify(result));
}

sumByTowns(["Sofia", "20", "Varna", "3", "Sofia", "5", "Varna", "4"])