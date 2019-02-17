function solve() {
	let answers = ["2013", "Pesho", "Nakov"];

	let correctAnswers = 0;
	let buttons = document.getElementsByTagName("button");

	for (let i = 0; i < buttons.length; i++) {
		buttons[i].addEventListener("click", () => buttonClick(i));
	}

	function buttonClick(i) {
		let selections = document.getElementsByTagName("section");

		let answer = selections[i].querySelector("input:checked").value;

		if (answer === answers[i]) {
			correctAnswers += 1;
		}

		if (i === 2) {
			let children = selections[i].children;

			let lastChild = children[children.length - 1];

			if (correctAnswers === 3) {
				lastChild.textContent = "You are recognized as top SoftUni fan!";
			}
			else {
				lastChild.textContent = `You have ${correctAnswers} right answers`;
			}
		}
		else {
			selections[i + 1].removeAttribute("class");
		}
	}
}