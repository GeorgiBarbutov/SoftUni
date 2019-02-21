function solve() {
  let elementToSearch = document.getElementById("num").value;
  let array = JSON.parse(document.getElementById("arr").value);

  let results = [];

  for (let i = 0; i < array.length; i++) {
    if(array[i].includes(elementToSearch)){
      let index  = array[i].indexOf(elementToSearch);

      results[i] = `true -> ${index}`;
    } else {
      results[i] = "false -> -1";
    }
  }

  let result = document.getElementById("result");

  result.textContent = results.join(",");
}