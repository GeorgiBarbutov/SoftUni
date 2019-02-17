function solve() {
    let body = document.querySelector("#exercise tbody");
    
    let searchButton = document.getElementById("searchBtn");
    searchButton.addEventListener("click", () => search());

    function search()
    {
        for (let i = 0; i < body.children.length; i++) {
            body.children[i].className = "";
            
        }

        let input = document.getElementById("searchField").value;

        let pattern = RegExp(input, "i");

        for (const row of body.children) {

            for (const element of row.children) {
                if (pattern.test(element.textContent)) {
                    row.setAttribute("class", "select");
                    break;
                }
            }
        }

        input = "";
    }
}