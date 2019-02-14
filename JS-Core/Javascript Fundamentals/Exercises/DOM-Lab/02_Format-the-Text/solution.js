function solve(){
  let inputText = document.getElementById('input').textContent;
  let splitedInput = inputText.split('.');
  let linesCount = splitedInput.length;

  let paragraphsCount = Math.ceil(linesCount / 3);

  for (let i = 0; i < paragraphsCount; i++) {
    let newParagraphElement = document.createElement('p');
    
    if(i < paragraphsCount - 1) {
      newParagraphElement.textContent = splitedInput[i * 3] + '.' + splitedInput[i * 3 + 1] + '.' + splitedInput[i * 3 + 2] + '.';
    }
    else {
      for (let j = 0; j < linesCount % 3; j++) {
        newParagraphElement.textContent += splitedInput[i * 3 + j] + '.';
        console.log(newParagraphElement);
      }
    }

    let outputElement = document.getElementById("output");

    outputElement.appendChild(newParagraphElement);
  }
}