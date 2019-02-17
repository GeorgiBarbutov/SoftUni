function solve() {
  let degrees = document.getElementById("num1").value;
  let type = String(document.getElementById("type").value).toLowerCase();

  let result = document.getElementById("result");

  function checkType(type, result) {
    if(type !== "fahrenheit" && type !== "celsius") {
      result.textContent = "Error!"

      return false;
    }
    return true;
  }

  function convertDegrees(degrees, type, result) {
    let converted;
    
    if(type === "fahrenheit")
    {
      converted = Math.round((degrees - 32) / 1.8);
    } else {
      converted = Math.round(degrees * 1.8 + 32);
    }

    result.textContent = converted;
  }

  let isValid = checkType(type, result);

  if(isValid){
    convertDegrees(degrees, type, result);
  }
}