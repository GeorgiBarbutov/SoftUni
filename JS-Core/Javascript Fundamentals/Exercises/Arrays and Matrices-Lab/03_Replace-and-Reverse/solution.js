function solve() {
  let input = document.getElementById("arr").value;
  let array = JSON.parse(input);

  let result = document.getElementById("result");

  for (let i = 0; i < array.length; i++) {
    array[i] = array[i].split("").reverse();

    array[i][0] = array[i][0].toUpperCase();

    array[i] = array[i].join("");
  }

  result.textContent = array.join(" ");
}