function cityMarkets(inputArray) {
    let data = {}

    for (let i = 0; i < inputArray.length; i++) {
        let townName = inputArray[i].split(" -> ")[0];
        let product = inputArray[i].split(" -> ")[1];
        let sales = inputArray[i].split(" -> ")[2].split(" : ")[0];
        let price = inputArray[i].split(" -> ")[2].split(" : ")[1];

        if(Object.keys(data).includes(townName)) {
            data[townName].push({[product]: sales * price});
        } else {
            let products = [];
            products.push({[product]: sales * price});

            data[townName] = products;
        }
    }

    for (const townName in data) {
        console.log(`Town - ${townName}`);
        
        for (const product of data[townName]) {
            let productName = Object.keys(product)[0];

            console.log(`$$$${productName} : ${product[productName]}`);
        }
    }
}

cityMarkets(["Town -> product -> 12 : 13", "aa -> bb -> 14 : 15"])