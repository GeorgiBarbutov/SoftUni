function coffeeMachine(input) {
    let totalEarnings = 0;

    for (const row of input) {
        let index = 0;

        let arguments = row.split(', ');

        let moneyInserted = +arguments[index];

        index += 1;
    
        let drinkType = arguments[index];
    
        index += 1;
        
        let basePrice = 0;
        if(drinkType === "coffee") {
            let typeOfCoffee = arguments[index];
    
            if(typeOfCoffee == "caffeine") {
                basePrice = 0.8;
            }
            else if (typeOfCoffee == "decaf"){
                basePrice = 0.9;
            }
            index += 1;
        }
        else {
            basePrice = 0.8;
        }
    
        let isMilk = arguments[index] === "milk";
    
        let milkExtra = 0;
        if(isMilk) {
            milkExtra = 0.1;
            index += 1;
        }
    
        let sugar = +arguments[index];
    
        let sugarExtra = 0;
        if(sugar !== 0) {
            sugarExtra = 0.1;
        }
        index += 1;
    
        let totalPrice = basePrice + milkExtra + sugarExtra;
    
        if(totalPrice > moneyInserted) {
            let moneyNeeded = totalPrice - moneyInserted;
    
            console.log(`Not enough money for ${drinkType}. Need ${moneyNeeded.toFixed(2)}$ more.`)
        }
        else {
            let change = moneyInserted - totalPrice;
    
            console.log(`You ordered ${drinkType}. Price: ${totalPrice.toFixed(2)}$ Change: ${change.toFixed(2)}$`);
        
            totalEarnings += totalPrice;
        }
    }
        
    console.log(`Income Report: ${totalEarnings.toFixed(2)}$`);
}

coffeeMachine(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2', '1.00, coffee, decaf, 0']);