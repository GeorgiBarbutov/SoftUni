function printArray(array){
    let delimiter = array[array.length - 1];
    
    let result = array.filter((number, index, arr) => index !== arr.length - 1).join(`${delimiter}`);

    console.log(result);
}