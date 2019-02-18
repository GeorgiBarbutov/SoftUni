function solve() {
    let button = document.querySelector("#exercise button");

    button.addEventListener("click", () => getCards());

    function getCards(){
        let from = document.getElementById("from").value.toLowerCase();
        let to = document.getElementById("to").value.toLowerCase();
        let suit = document.getElementsByTagName("select")[0].value.split(" ")[1];

        from = getNumberFromLetter(from);
        to = getNumberFromLetter(to);

        let selection = document.getElementById("cards");

        for (let i = from; i <= to; i++) {
            let newDiv = document.createElement("div");

            newDiv.setAttribute("class", "card");

            let suitP1 = document.createElement("p");
            let suitP2 = document.createElement("p");

            suitP1.textContent = suit;
            suitP2.textContent = suit;

            let numberP = document.createElement("p");

            numberP.textContent = getLetterFromNumber(i);

            newDiv.appendChild(suitP1);
            newDiv.appendChild(numberP);
            newDiv.appendChild(suitP2);

            selection.appendChild(newDiv);
        }
    }

    function getNumberFromLetter(letter) {
        if (letter === "j") {
            letter = 11;
        }
        else if (letter === "q") {
            letter = 12;
        }
        else if (letter === "k") {
            letter = 13;
        }
        else if (letter === "a") {
            letter = 14;
        }
        return letter;
    }

    function getLetterFromNumber(number) {
        if (number === 11) {
            number = "J";
        }
        else if (number === 12) {
            number = "Q";
        }
        else if (number === 13) {
            number = "K";
        }
        else if (number === 14) {
            number = "A";
        }
        return number;
    }
}