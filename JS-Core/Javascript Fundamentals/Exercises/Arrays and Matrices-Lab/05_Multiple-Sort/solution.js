function solve() {
  let array = JSON.parse(document.getElementById("arr").value);

  let ascendedArray = array.sort((a, b) => a - b);
  
  let div1 = document.createElement("div");
  div1.textContent = ascendedArray.join(", ");

  let alphabeticalArray = array.sort();

  let div2 = document.createElement("div");
  div2.textContent = alphabeticalArray.join(", ");

  let result = document.getElementById("result");

  result.appendChild(div1);
  result.appendChild(div2);
}