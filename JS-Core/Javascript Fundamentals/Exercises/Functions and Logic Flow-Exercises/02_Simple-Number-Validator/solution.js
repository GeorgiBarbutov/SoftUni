function validate() {
    let button = document.querySelector("#exercise fieldset div button");

    button.addEventListener("click", () => buttonClick())

    function buttonClick() {
        let inputNumber = document.querySelector("#exercise fieldset div input").value;

        let isTenDigitNumber = inputNumber.length === 10;

        let isValid = false;

        if(isTenDigitNumber){
            let lastDigit = inputNumber[9];

            let sum = getSum(inputNumber);

            isValid = getIsValid(sum, lastDigit);
        }

        print(isValid);

    }

    function print(isValid) {
        let response = document.getElementById("response");

        if (isValid) {
            response.textContent = "This number is Valid!";
        }
        else {
            response.textContent = "This number is NOT Valid!";
        }
    }

    function getIsValid(sum, lastDigit) {
        let remainder = sum % 11;

        if (remainder === 10) {
            remainder = 0;
        }
        let isValid = +lastDigit === remainder;

        return isValid;
    }

    function getSum(inputNumber) {
        let array = [2, 4, 8, 5, 10, 9, 7, 3, 6];

        let sum = 0;

        for (let i = 0; i < array.length; i++) {
            sum += +(inputNumber[i]) * array[i];
        }
        
        return sum;
    }
}