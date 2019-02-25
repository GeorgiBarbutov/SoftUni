function solve() {
  let array = document.getElementById("str").value.split(" ");

  let words = array.filter(word => !Number(word));
  let numbers = array.filter(word => Number(word));

  let result = document.getElementById("result");
  result.textContent = "";

  for (const word of words) {
    let text = word.split("").map((letter, index) => word.charCodeAt(index)).join(" ");

    addToResult(text);
  }

  let word = numbers.map(number => String.fromCharCode(number)).join("");

  addToResult(word);

  function addToResult(text) {
    let p = document.createElement("p");

    p.textContent += text;

    result.appendChild(p);
  }
}