function countWordsWithMaps (inputText) {
    let matches = inputText[0].match(/[A-Za-z_]+/g);
    
    let object = {};

    for (let i = 0; i < matches.length; i++) {
        if(Object.keys(object).includes(matches[i].toLowerCase())){
            object[matches[i].toLowerCase()] += 1;
        } else {
            object[matches[i].toLowerCase()] = 1;
        }
    }

    let sortedObject = Object.keys(object).sort().map(key => `'${key}' -> ${object[key]} times`);

    console.log(sortedObject.join("\n"));
}

countWordsWithMaps(["JS devs use Node.js for server-side JS.-- JS for devs"]);