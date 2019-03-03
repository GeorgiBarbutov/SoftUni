function countWordsInAText(inputText) {
    let matches = inputText[0].match(/[A-Za-z_]+/g);
    
    let resultObject = {};

    for (let i = 0; i < matches.length; i++) {
        if(Object.keys(resultObject).includes(matches[i])){
            resultObject[matches[i]] += 1;
        } else {
            resultObject[matches[i]] = 1;
        }
    }

    console.log(JSON.stringify(resultObject));
}

countWordsInAText(["JS devs use Node.js for server-side JS.-- JS for devs"]);