function solve() {
  let arrayInput = JSON.parse(document.getElementById("arr").value);

  let replacementWord = document.getElementById("str").value;

  let result = document.getElementById("result");

  let wordToReplace = arrayInput[0].split(" ")[2].toLowerCase();

  arrayInput.forEach(element => {
    let regex = new RegExp(wordToReplace, "i");

    element = element.replace(regex, replacementWord);

    let p = document.createElement("p");

    p.textContent = element;
    
    result.appendChild(p);
  });
}