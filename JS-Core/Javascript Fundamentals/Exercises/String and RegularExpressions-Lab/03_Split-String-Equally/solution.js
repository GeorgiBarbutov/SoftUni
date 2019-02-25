function solve() {
  let inputText = document.getElementById("str").value;
  let inputNumber = Number(document.getElementById("num").value);

  let resultText = [];

  if(inputText.length % inputNumber === 0) {
    for (let i = 0; i < inputText.length; i+=inputNumber) {
      resultText.push(inputText.substr(i, inputNumber));
    }
  } else {
    let cycles = 0
    
    for (let i = 0; i < inputText.length; i+=inputNumber) {
      resultText.push(inputText.substr(i, inputNumber));

      cycles += 1;
    }


    resultText[resultText.length - 1] += (inputText.substr(0, (inputNumber * cycles) - inputText.length));
  }

  let result = document.getElementById("result");

  result.textContent = resultText.join(" ");
}