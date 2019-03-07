function greatestCD(num1, num2) {
    while(num2 !== 0)
    {
        let num2OldValue = num2;
        num2 = num1 % num2;
        num1 = num2OldValue;
    }

    return num1;
}