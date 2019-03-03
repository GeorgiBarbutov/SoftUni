function townsToJSON(strings){
    let headings = strings[0].split("|")
        .filter(x => x !== "")
        .map(row => row.trim());

    let rows = strings.filter((value, index) => index !== 0)
        .map((row) => row.split("|").filter(x => x !== "").map((row, index) => {
            let newValue = row.trim();

            if (index > 0) {
                newValue = Number(newValue);
            }

            return newValue;
        }));
        
    let outputArray = []

    for (let i = 0; i < rows.length; i++) {
        outputArray[i] = {
            [headings[0]]: rows[i][0],
            [headings[1]]: rows[i][1],
            [headings[2]]: rows[i][2] 
        };
    }

    console.log(JSON.stringify(outputArray));
}

townsToJSON(['| Town | Latitude | Longitude |', '| Veliko Turnovo | 43.0757 | 25.6172 |', '| Monatevideo | 34.50 | 56.11 |'])