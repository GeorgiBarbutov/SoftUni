function solve() {
    let words = document.getElementById("str1").value.split(" ");
    let camelOrPascalCase = document.getElementById("str2").value;

    let resultText = "";

    for (let i = 0; i < words.length; i++) {
        if(camelOrPascalCase === "Camel Case") {
            if(i === 0) {
                resultText += words[i].toLowerCase();
            } else {
                resultText += words[i].charAt(0).toUpperCase() + words[i].substr(1).toLowerCase();
            }
        } else if(camelOrPascalCase === "Pascal Case") {
            resultText += words[i].charAt(0).toUpperCase() + words[i].substr(1).toLowerCase();
        } else {
            resultText = "Error!";
            break;
        }
    }

    let result = document.getElementById("result");
    result.innerHTML = resultText;
}