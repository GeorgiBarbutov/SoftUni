function solve() {
  let string = String(document.getElementById("string").value);

  let result = document.getElementById("result");

  function findUniqueChars(string) {
    let foundChars = [];

    for (let i = 0; i < string.length; i++) {
      if(string[i] === " " || !foundChars.includes(string[i])) {
        foundChars.push(string[i]);
      }
    }

    return foundChars.join("");
  }

  let newString = findUniqueChars(string);

  result.textContent = newString;
}