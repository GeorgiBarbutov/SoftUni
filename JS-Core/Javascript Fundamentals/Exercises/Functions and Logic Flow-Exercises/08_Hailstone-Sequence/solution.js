function getNext() {
    let n = Number(document.getElementById("num").value);
    let result = `${n} `; 

    getResult(result, n);

    let resultElement = document.getElementById("result");

    resultElement.textContent = result;

    function getResult(n) {
        while (n !== 1) {

            if (n % 2 === 0) {
                n = n / 2;
            }
            else {
                n = (3 * n) + 1;
            }
            result += `${n} `;
        }
    }
}