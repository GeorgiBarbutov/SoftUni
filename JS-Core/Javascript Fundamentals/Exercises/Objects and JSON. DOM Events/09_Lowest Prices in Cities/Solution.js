function lowestPricesInCities(inputArray) {
    let data = {};
    
    let productNames = [];
    for (const element of inputArray) {
        let townName = element.split(" | ")[0];
        let productName = element.split(" | ")[1];
        let price = Number(element.split(" | ")[2]);

        if(data.hasOwnProperty(townName)) {
            if(!data[townName].hasOwnProperty(productName) && !productNames.includes(productName)){
                productNames.push(productName);
            }

            data[townName][productName] = price;
        } else {
            let products = {};
            products[productName] = price;

            data[townName] = products;
            
            if(!productNames.includes(productName)){
                productNames.push(productName);
            }
        }
    }

    for (const product of productNames) {
        let townFound = "";
        let lowestPrice = Number.MAX_VALUE;

        for (const townName in data) {
            if (data[townName].hasOwnProperty(product) && data[townName][product] < lowestPrice) {
                lowestPrice = data[townName][product];
                townFound = townName;
            }
        }

        console.log(`${product} -> ${lowestPrice} (${townFound})`);
    }
}

lowestPricesInCities(["Sofia City | Audi | 100000",
"Sofia City | BMW | 100000",
"Sofia City | Mitsubishi | 10000",
"Sofia City | Mercedes | 10000",
"Sofia City | NoOffenseToCarLovers | 0",
"Mexico City | Audi | 1000",
"Mexico City | BMW | 99999",
"New York City | Mitsubishi | 10000",
"New York City | Mitsubishi | 1000",
"Mexico City | Audi | 100000",
"Washington City | Mercedes | 1000"]);