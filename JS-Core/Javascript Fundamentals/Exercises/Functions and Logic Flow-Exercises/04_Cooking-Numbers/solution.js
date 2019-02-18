function solve() {
    let allButtons = document.querySelectorAll("#operations button");

    allButtons[0].addEventListener("click", () => template((param) => chop(param)));
    allButtons[1].addEventListener("click", () => template((param) => dice(param)));
    allButtons[2].addEventListener("click", () => template((param) => spice(param)));
    allButtons[3].addEventListener("click", () => template((param) => bake(param)));
    allButtons[4].addEventListener("click", () => template((param) => fillet(param)));

    function getCurrentOutput() {
        let currentOutput = document.getElementById("output").textContent;

        if (currentOutput === "") {
            currentOutput = document.querySelector("#exercise input").value;

            if(currentOutput === ""){
                currentOutput = 0;
            }
        }
        
        return currentOutput;
    }

    function template(func){
        let currentOutput = getCurrentOutput();

        let result = func(currentOutput);

        let output = document.getElementById("output");

        output.textContent = result;
    }

    function chop(currentOutput){
        return Number(currentOutput) / 2;
    }

    function dice(currentOutput){
        return Math.sqrt(Number(currentOutput));
    }

    function spice(currentOutput){
        return Number(currentOutput) + 1;
    }

    function bake(currentOutput){
        return Number(currentOutput) * 3;
    }

    function fillet(currentOutput){
        return Number(currentOutput) * 0.8;
    }
}
