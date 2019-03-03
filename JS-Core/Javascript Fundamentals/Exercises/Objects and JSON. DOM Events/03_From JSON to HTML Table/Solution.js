function fromJSONtoHTMLTable(inputJSON){
    let array = JSON.parse(inputJSON);

    let result = "<table>\n   <tr>";

    let headings = [];
    for (const key in array[0]) {
        headings.push(key);

        result += `<th>${key}</th>`;
    }

    result += "</tr>\n";

    for (let i = 0; i < array.length; i++) {
        result += "   <tr>";

        let keys = [];
        for (const key in array[i]) {
            keys.push(key);
        }

        for (let j = 0; j < headings.length; j++) {
            let escapedValue = escapeHtml(array[i][keys[j]]);  

            result += `<td>${escapedValue}</td>`;
        }

        result += "</tr>\n";
    }

    result += "</table>";

    console.log(result);

    function escapeHtml(unsafe) {
        if(isNaN(unsafe))
        {
            return unsafe
                .replace(/&/g, "&amp;")
                .replace(/</g, "&lt;")
                .replace(/>/g, "&gt;")
                .replace(/"/g, "&quot;")
                .replace(/'/g, "&#39;");
        }

        return unsafe;
     }
}

fromJSONtoHTMLTable('[{"Name":"Pesho <div>-a","Age":20,"City":"Sofia"},{"Name":"Gosho","Age":18,"City":"Plovdiv"},{"Name":"Angel","Age":18,"City":"Veliko Tarnovo"}]');