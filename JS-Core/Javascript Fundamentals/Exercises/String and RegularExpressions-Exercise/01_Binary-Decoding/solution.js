function solve() {
  let inputString = document.getElementById("str").value;
  let result = document.getElementById("result");

  let sum = 0;
  for (let i = 0; i < inputString.length; i++) {
    if (inputString[i] === "1") {
      sum += 1;
    }
  }

  if(sum >= 10){
    sum = getSum(sum);
  }

  inputString = inputString.substring(sum, inputString.length - sum);

  let splitedString = [];
  for (let i = 0; i < inputString.length / 8; i++) {
    splitedString[i] = inputString.substring(i * 8, (i * 8) + 8);
  }

  let asciiCodes = [];

  let resultString = ""; 

  for (let i = 0; i < splitedString.length; i++) {
    asciiCodes[i] = parseInt(splitedString[i], 2);

    if((asciiCodes[i] >= 65 && asciiCodes[i] <= 90) || (asciiCodes[i] >= 96 && asciiCodes[i] <= 122)) {
      resultString += String.fromCharCode(asciiCodes[i]);
    }
  }

  result.textContent = resultString;

  function getSum(sum) {
    let newSum = 0;

    do {
      newSum += sum % 10;

      sum = Math.floor(sum / 10);
    } while(sum !== 0);

    if(newSum >= 10) {
      newSum = getSum(newSum);
    }

    return newSum;
  }
}