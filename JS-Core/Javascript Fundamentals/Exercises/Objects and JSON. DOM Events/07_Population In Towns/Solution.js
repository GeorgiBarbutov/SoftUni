function populationInTowns(inputArray) {
    let data = {};
    
    for (let i = 0; i < inputArray.length; i++) {
        let townName = inputArray[i].split(" <-> ")[0];
        let population = inputArray[i].split(" <-> ")[1];

        if(Object.keys(data).includes(townName)){
            data[townName] += Number(population);
        } else {
            data[townName] = Number(population);
        }
    }

    for (const townName in data) {
        console.log(`${townName} : ${data[townName]}`);
    }
}

populationInTowns(["Sofia <-> 1200000", "Montana <-> 20000"])