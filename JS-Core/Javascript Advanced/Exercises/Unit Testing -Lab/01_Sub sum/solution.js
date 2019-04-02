function subSum(array, startIndex, endIndex) {
    if(!(array instanceof Array)){
        return NaN;
    }

    if(array.length === 0){
        return 0;
    }

    if(startIndex < 0){
        startIndex = 0;
    }
    if(endIndex > array.length){
        endIndex = array.length - 1;
    }

    let sum = 0;

    for (let i = startIndex; i <= endIndex; i++) {
        sum += Number(array[i]);
    }

    return sum;
}

console.log(subSum([], 0, 0));