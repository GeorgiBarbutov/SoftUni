function solve() {
    let buttons = document.getElementsByTagName("button");
    
    for (const button of buttons) {
        button.addEventListener("click", () => {
            let newDiv = document.createElement("div");

            let sender;
            let text;

            if (button.name === "myBtn") {
                sender = "Me";

                text = document.getElementById("myChatBox").value;
            }
            else {
                sender = "Pesho";

                text = document.getElementById("peshoChatBox").value;
            }

            let newSpan = document.createElement("span");
            newSpan.textContent = sender;

            if(sender === "Me") {
                newDiv.style.textAlign = "left";
            }
            else {
                newDiv.style.textAlign = "right";
            }

            let newParagraph = document.createElement("p");
            newParagraph.textContent = text;

            newDiv.appendChild(newSpan);
            newDiv.appendChild(newParagraph);

            document.getElementById("chatChronology").appendChild(newDiv);

            document.getElementById("myChatBox").value = "";
            document.getElementById("peshoChatBox").value = "";
        })
    }
}