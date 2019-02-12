function GetSum(num1, num2){
    let sum = 0;
    
    for(i = Number(num1); i <= Number(num2); i++)
    {
        sum += Number(i);
    }

    console.log(sum);
}