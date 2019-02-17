function solve() {
    let player1Element = document.getElementById("player1Div");
    let player2Element = document.getElementById("player2Div");

    let resultElement = document.getElementById("result");

    let historyElement = document.getElementById("history");

    for (const cardElement of player1Element.children) {
        cardElement.addEventListener("click", () => {
            cardElement.setAttribute("src", "images/whiteCard.jpg");

            resultElement.children[0].textContent = cardElement.getAttribute("name");

            if(resultElement.children[2].textContent !== '') {
                let otherElement = player2Element.children.namedItem(resultElement.children[2].textContent);

                if(+resultElement.children[2].textContent < +resultElement.children[0].textContent){
                    cardElement.setAttribute("style", "border: 2px solid green");
                    otherElement.setAttribute("style", "border: 2px solid darkred");
                }
                else{
                    cardElement.setAttribute("style", "border: 2px solid darkred");
                    otherElement.setAttribute("style", "border: 2px solid green");
                }

                historyElement.textContent += ` [${+resultElement.children[0].textContent} vs ${+resultElement.children[2].textContent}]`;

                setTimeout(() => {
                    resultElement.children[0].textContent = '';
                    resultElement.children[2].textContent = '';
                }, 2000);
            }
        })

        
    }
    for (const cardElement of player2Element.children) {
        cardElement.addEventListener("click", () => {
            cardElement.setAttribute("src", "images/whiteCard.jpg");

            resultElement.children[2].textContent = cardElement.getAttribute("name");

            if(resultElement.children[0].textContent !== '') {
                let otherElement = player1Element.children.namedItem(resultElement.children[0].textContent);

                if(+resultElement.children[2].textContent < +resultElement.children[0].textContent){
                    cardElement.setAttribute("style", "border: 2px solid darkred");
                    otherElement.setAttribute("style", "border: 2px solid green");
                }
                else{
                    cardElement.setAttribute("style", "border: 2px solid green");
                    otherElement.setAttribute("style", "border: 2px solid darkred");
                }

                historyElement.textContent += ` [${+resultElement.children[0].textContent} vs ${+resultElement.children[2].textContent}]`;

                setTimeout(() => {
                    resultElement.children[0].textContent = '';
                    resultElement.children[2].textContent = '';
                }, 2000);
            }
        })
    }
    
}