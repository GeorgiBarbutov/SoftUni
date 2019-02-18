function greatestCD() {
        let num1 = Number(document.getElementById("num1").value);
        let num2 = Number(document.getElementById("num2").value);
    
        while(num2 !== 0)
        {
            let num2OldValue = num2;
            num2 = num1 % num2;
            num1 = num2OldValue;
        }
    
        let result = document.getElementById("result");

        result.textContent = num1;
}