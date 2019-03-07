function argumentList() {
    let foundTypes = {};

    for (const argument of arguments) {
        let type = typeof(argument);
        
        if(foundTypes.hasOwnProperty(type)){
            foundTypes[type] += 1;
        } else {
            foundTypes[type] = 1;
        }

        console.log(`${type}: ${argument}`);
    }

    let sortedKeys = Object.keys(foundTypes).sort((a, b) => foundTypes[b] - foundTypes[a])

    for (const key of sortedKeys) {
        console.log(`${key} = ${foundTypes[key]}`);
    }
}

argumentList({ name: 'bob'}, 3.333, 9.999);