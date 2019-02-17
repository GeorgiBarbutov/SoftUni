function solve() {
	let noSignal = document.getElementById("exercise");

	setInterval(() => {
		let vertical = Math.floor((Math.random() * 45) + 1);
		let horizontal = Math.floor((Math.random() * 81) + 1);

		noSignal.style.marginTop = `${vertical}%`;
		noSignal.style.marginLeft = `${horizontal}vh`;
	}, 2000);
}