function scoreToHTML(inputJSON){
    let array = JSON.parse(inputJSON);

    let result = "<table>\n   <tr>";

    for (const key in array[0]) {
        result += `<th>${key}</th>`;
    }

    result += "</tr>\n";

    for (let i = 0; i < array.length; i++) {
        result += "   <tr>";

        let escapedName = escapeHtml(array[i]["name"]);

        result += `<td>${escapedName}</td>`;

        let escapedScore = array[i]["score"];

        result += `<td>${escapedScore}</td>`;

        result += "</tr>\n";
    }

    result += "</table>";

    console.log(result);

    function escapeHtml(unsafe) {
        return unsafe
             .replace(/&/g, "&amp;")
             .replace(/</g, "&lt;")
             .replace(/>/g, "&gt;")
             .replace(/"/g, "&quot;")
             .replace(/'/g, "&#39;");
     }
}

scoreToHTML('[{"name":"Pesho","score":479},{"name":"Gosho","score":205}]')