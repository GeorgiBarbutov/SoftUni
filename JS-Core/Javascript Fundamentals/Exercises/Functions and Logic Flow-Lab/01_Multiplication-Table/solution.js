function solve() {
  let num1 = Number(document.getElementById("num1").value);
  let num2 = Number(document.getElementById("num2").value);

  let result = document.getElementById("result");

  if(num1 > num2) {
    result.textContent = "Try with other numbers.";
  } else {
    print();
  }

  function print() {
    for (let i = num1; i <= num2; i++) {
      let p = document.createElement("p");
      p.textContent = `${i} * ${num2} = ${i * num2}`;
      result.appendChild(p);
    }
  }
}