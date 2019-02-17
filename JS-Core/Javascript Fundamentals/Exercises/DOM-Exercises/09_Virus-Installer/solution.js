function solve() {
    let isZeroStep = true;
    let isFirstStep = false;
    let isSeconStep = false;

    let firstStep = document.getElementById("firstStep");
    let secondStep = document.getElementById("secondStep");
    let thirdStep = document.getElementById("thirdStep");

    let buttons = document.getElementsByTagName("button");
    let nextButton = buttons[0];
    let cancelButton = buttons[1];

    nextButton.addEventListener("click", () => next());
    cancelButton.addEventListener("click", () => cancel());

    function cancel()
    {
        let section = document.getElementsByTagName("section")[0];
    
        section.style.display = "none";
    }

    function next() {
        if (isZeroStep) {
            let content = document.getElementById("content");
            content.style.backgroundImage = "none";

            firstStep.style.display = "block";

            isZeroStep = false;
            isFirstStep = true;
        }
        else if (isFirstStep) {
            let agreed = firstStep.querySelector("input:checked").value;

            if (agreed === "agree") {
                firstStep.style.display = "none";
                
                secondStep.style.display = "block";

                isFirstStep = false;
                isSeconStep = true;
        
                nextButton.style.display = "none";

                setTimeout(() => {
                    nextButton.style.display = "inline";
                }, 3000);
            }
        }
        else if (isSeconStep) {
            isSeconStep = false;
            isThirdStep = true;
            
            secondStep.style.display = "none";
                
            thirdStep.style.display = "block";
        
            nextButton.style.display = "none";

            cancelButton.textContent = "Finish";
        }
    }
}