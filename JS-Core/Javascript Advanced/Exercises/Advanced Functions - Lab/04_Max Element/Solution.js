function maxElement(arr){
    return arr.reduce((prev, cur) => cur > prev ? cur : prev);
}

maxElement([10, 20, 5]);