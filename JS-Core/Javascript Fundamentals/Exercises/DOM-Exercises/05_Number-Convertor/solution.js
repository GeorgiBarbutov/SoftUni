function solve() {
    let selectionMenu = document.getElementById("selectMenuTo");

    let binary = document.createElement("option");
    let hexadecimal = document.createElement("option");

    binary.selected = "binary";
    binary.textContent = "Binary";
    hexadecimal.value = "hexadecimal";
    hexadecimal.textContent = "Hexadecimal";

    selectionMenu.appendChild(binary);
    selectionMenu.appendChild(hexadecimal);

    let button = document.querySelector("#menus button");
    button.addEventListener("click", () => convert());

    function convert() {
        let number = document.getElementById("input").value;

        let numberBase = document.getElementById("selectMenuTo").value;

        let newNumber;
        if (numberBase === "Binary") {
            newNumber = (+number).toString(2);
        } else {
            newNumber = (+number).toString(16);
        }

        document.getElementById("result").value = newNumber;
    }
}