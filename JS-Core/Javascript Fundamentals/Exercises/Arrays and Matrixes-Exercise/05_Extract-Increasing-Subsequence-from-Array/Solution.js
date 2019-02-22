function extractSubsequence(array){
    let maxValue = Number.MIN_SAFE_INTEGER;

    for(let number of array){
        if(maxValue <= number){
            maxValue = number;

            console.log(number);
        }
    };
}

extractSubsequence([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]);