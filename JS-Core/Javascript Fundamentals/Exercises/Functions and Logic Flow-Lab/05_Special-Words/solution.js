function solve() {
  let lowerBound = Number(document.getElementById("firstNumber").value);
  let upperBound = Number(document.getElementById("secondNumber").value);

  let firstString = document.getElementById("firstString").value;
  let secondString = document.getElementById("secondString").value;
  let thirdString = document.getElementById("thirdString").value;

  let result = document.getElementById("result");

  function iterate(lowerBound, upperBound, firstString, secondString, thirdString, result) { 
    console.log(lowerBound);
    console.log(upperBound);
    console.log(firstString);
    console.log(secondString);
    console.log(thirdString);
    for (let i = lowerBound; i <= upperBound; i++) {
      console.log("i")
      let p = document.createElement("p");

      p.textContent = `${i}`;

      if(i % 15 === 0) {
        p.textContent += ` ${firstString}-${secondString}-${thirdString}`;
      } else if(i % 5 === 0){
        p.textContent += ` ${thirdString}`;
      } else if(i % 3 === 0){
        p.textContent += ` ${secondString}`;
      }
      
      result.appendChild(p);
    }
  }

  iterate(lowerBound, upperBound, firstString, secondString, thirdString, result);
}