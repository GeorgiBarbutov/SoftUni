function solve() {
	let encodeButton = document.getElementsByTagName("button")[0];

	encodeButton.addEventListener("click", () => encodeAndSend());	

	let dencodeButton = document.getElementsByTagName("button")[1];

	dencodeButton.addEventListener("click", () => dencodeAndSend());

	function encodeAndSend(){
		let inputTextArea = document.getElementsByTagName("textarea")[0];
		let text = inputTextArea.value;

		let newText = "";

		for (let i = 0; i < text.length; i++) {
			newText += String.fromCharCode(text.charCodeAt(i) + 1);
		}

		inputTextArea.value = "";

		let receiverTextArea = document.getElementsByTagName("textarea")[1];

		receiverTextArea.textContent = newText;
	}

	function dencodeAndSend(){
		let textArea = document.getElementsByTagName("textarea")[1];
		let text = textArea.textContent;
		console.log(text)
		let newText = "";

		for (let i = 0; i < text.length; i++) {
			newText += String.fromCharCode(text.charCodeAt(i) - 1);
		}

		textArea.textContent = newText;
	}
}