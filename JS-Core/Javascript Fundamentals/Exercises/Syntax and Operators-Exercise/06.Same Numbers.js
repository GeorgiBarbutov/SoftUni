function sameNumbers (input) {
    let firstDigit = input.toString()[0];
    let allNumbersAreTheSame = true;

    for (let i = 1; i < input.toString().length; i++) {
        if(input.toString()[i] !== firstDigit) {
            allNumbersAreTheSame = false;
            break;
        }
    }
    
    console.log(allNumbersAreTheSame);

    let sum = 0;
 
    for (let i = 0; i < input.toString().length; i++) {
        sum += +input.toString()[i];    
    }

    console.log(sum);
}

sameNumbers(224222);