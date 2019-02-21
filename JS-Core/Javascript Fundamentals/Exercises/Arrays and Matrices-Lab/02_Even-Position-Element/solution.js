function solve() {
    let input = document.getElementById("arr").value;
    let array = input.substring(1, input.length - 1).split(", ");

    let result = document.getElementById("result");
    result.textContent = `${array[0]}`;

    for (let i = 2; i < array.length; i+=2) {
      result.textContent += ` x ${array[i]}`;
    }
}