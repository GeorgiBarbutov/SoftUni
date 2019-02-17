function solve() {
	let myNumbers = document.getElementById("myNumbers");
	let button = myNumbers.querySelector("button");

	button.addEventListener("click", () => getNumbers());

	function getNumbers() {
		let numbersString = myNumbers.querySelector("input").value;
		let splitedNumbersString = numbersString.split(" ")

		let inputIsLegit = true;

		let numbers = [];

		if (splitedNumbersString.length !== 6) {
			inputIsLegit = false;
		}
		else {
			for(let i = 0; i < splitedNumbersString.length; i++) {
				if (+splitedNumbersString[i] < 1 || +splitedNumbersString[i] > 49) {
					inputIsLegit = false;
					break;
				}
				else {
					numbers[i] = +splitedNumbersString[i];
				}
			}
		}

		if (inputIsLegit) {
			let allNumbersDiv = document.getElementById("allNumbers");

			for (let i = 0; i < 49; i++) {
				let newDiv = document.createElement("div");
				newDiv.className = "numbers";
				newDiv.textContent = i + 1;

				if (numbers.includes(i + 1)) {
					newDiv.style.backgroundColor = "orange";
				}

				allNumbersDiv.appendChild(newDiv);
			}

			button.disabled = true;
			myNumbers.querySelector("input").disabled = true;
		}
	}
}