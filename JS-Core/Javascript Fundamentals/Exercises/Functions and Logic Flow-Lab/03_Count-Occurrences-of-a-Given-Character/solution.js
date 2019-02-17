function solve() {
  let string = String(document.getElementById("string").value);
  let char = String(document.getElementById("character").value);

  let result = document.getElementById("result");

  function findOccurences(string, char) {
    let matches = 0;
    
    for (let i = 0; i < string.length; i++) {
      if(string[i] === char) {
        matches += 1;
      }
    }

    return matches;
  }

  function evenOrOdd(number, char, result) {
    if(number % 2 === 0) {
      result.textContent = `Count of ${char} is even.`; 
    } else {
      result.textContent = `Count of ${char} is odd.`; 
    }
  }

  let matches = findOccurences(string, char);
  evenOrOdd(matches, char, result);
}