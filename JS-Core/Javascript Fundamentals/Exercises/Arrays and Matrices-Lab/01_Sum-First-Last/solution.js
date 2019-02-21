function solve() {
    let elementsString = String(document.getElementById("arr").value);
    
    let elements = elementsString.substring(2, elementsString.length - 2).split('", "');

    let result = document.getElementById("result");

    for (let i = 0; i < elements.length; i++) {
        let p = document.createElement("p");
        p.textContent = `${i} -> ${elements[i] * elements.length}`;
        result.appendChild(p); 
    }
}