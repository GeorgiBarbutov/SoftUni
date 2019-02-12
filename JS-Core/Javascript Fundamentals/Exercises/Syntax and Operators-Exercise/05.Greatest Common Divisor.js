function findGCD(input1, input2) {
    let num1 = +input1;
    let num2 = +input2;

    while(num2 != 0)
    {
        let num2OldValue = num2;
        num2 = num1 % num2;
        num1 = num2OldValue;
    }

    console.log(num1);
}

findGCD(10, 12);