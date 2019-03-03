function eVenetkaBG(vignettes){
    let townProfits = {};
    let vignettesInTowns = {};

    for (let i = 0; i < vignettes.length; i++) {
        let townName = vignettes[i].town;

        if(townProfits.hasOwnProperty(townName)){
            townProfits[townName] += vignettes[i].price;
            vignettesInTowns[townName] += 1;
        } else{
            townProfits[townName] = vignettes[i].price;
            vignettesInTowns[townName] = 1;
        }
    }

    let mostProfitableTownName = "";
    let maxProfit = Number.MIN_VALUE;

    for (const key in townProfits) {
        if(townProfits[key] > maxProfit){
            maxProfit = townProfits[key];
            mostProfitableTownName = key;
        } else if(townProfits[key] === maxProfit){
            if(vignettesInTowns[key] > vignettesInTowns[mostProfitableTownName]){
                maxProfit = townProfits[key];
                mostProfitableTownName = key;
            } else if(vignettesInTowns[key] === vignettesInTowns[mostProfitableTownName]){
                if(key.localeCompare(mostProfitableTownName) === -1){
                    maxProfit = townProfits[key];
                    mostProfitableTownName = key;
                }
            }
        }
    }

    console.log(`${mostProfitableTownName} is most profitable - ${maxProfit} BGN`);

    let townVignettes = vignettes.filter(v => v.town === mostProfitableTownName);

    let modelsPrices = {};
    let modelsDriven = {};
    for (let i = 0; i < townVignettes.length; i++) {
        let modelName = townVignettes[i].model;

        if(modelsPrices.hasOwnProperty(modelName)){
            modelsPrices[modelName] += townVignettes[i].price;
            modelsDriven[modelName] += 1;
        } else{
            modelsPrices[modelName] = townVignettes[i].price;
            modelsDriven[modelName] = 1;
        }
    }

    let mostDrivenModelName = "";
    let timesDriven = 0;

    for (const key in modelsDriven) {
        if(modelsDriven[key] > timesDriven){
            timesDriven = modelsDriven[key];
            mostDrivenModelName = key;
        } else if(modelsDriven[key] === timesDriven){
            if(modelsPrices[key] > modelsPrices[mostDrivenModelName]){
                timesDriven = modelsDriven[key];
                mostDrivenModelName = key;
            } else if(modelsPrices[key] === modelsPrices[mostDrivenModelName]){
                if(key.localeCompare(mostDrivenModelName) === -1){
                    timesDriven = modelsDriven[key];
                    mostDrivenModelName = key;
                }
            }
        }
    }

    console.log(`Most driven model: ${mostDrivenModelName}`);

    let townsWithMostDrivenModel = vignettes.filter(v => v.model === mostDrivenModelName)
        .sort((a, b) => a.town.localeCompare(b.town));

    let currentTownName = ""; 
    let result = "";
    
    for (let i = 0; i < townsWithMostDrivenModel.length; i++) {
        if(townsWithMostDrivenModel[i].town === currentTownName){
            result += `, ${townsWithMostDrivenModel[i].regNumber}`
        } else{
            if(i !== 0){
                result += `\n`;
            }

            result += `${townsWithMostDrivenModel[i].town}: ${townsWithMostDrivenModel[i].regNumber}`;

            currentTownName = townsWithMostDrivenModel[i].town;
        }
    }

    console.log(result);
}

eVenetkaBG([ { model: 'BMW', regNumber: 'B1234SM', town: 'Varna', price: 11},
{ model: 'BMW', regNumber: 'C5959CZ', town: 'Zofia', price: 8},
{ model: 'Tesla', regNumber: 'NIKOLA', town: 'Burgas', price: 9},
{ model: 'BMW', regNumber: 'A3423SM', town: 'Varna', price: 9},
{ model: 'Lada', regNumber: 'SJSCA', town: 'Zofia', price: 3} ]
)