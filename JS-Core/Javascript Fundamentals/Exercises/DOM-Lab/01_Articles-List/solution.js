function solve() {
	let title = document.getElementById("createTitle").value;
	let content = document.getElementById("createContent").value;
	let articles = document.getElementById("articles");

	if(title !== '' && content !== '')
	{
		let newArticle = document.createElement("article");

		let newTitle = document.createElement("h3");
		newTitle.textContent = title;
		let newContent = document.createElement("p");
		newContent.textContent = content;

		newArticle.appendChild(newTitle);
		newArticle.appendChild(newContent);
		articles.appendChild(newArticle);
	}

	document.getElementById("createTitle").value = "";
	document.getElementById("createContent").value = "";
}