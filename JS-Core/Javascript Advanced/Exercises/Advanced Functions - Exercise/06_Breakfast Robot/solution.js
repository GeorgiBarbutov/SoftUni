let manager = (function breakfastRobot(){
    let availableMicroelements = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    }

    let recepies = {
        apple: {
            protein: 0,
            carbohydrate: 1,
            fat: 0,
            flavour: 2,
        },
        coke: {
            protein: 0,
            carbohydrate: 10,
            fat: 0,
            flavour: 20,
        },
        burger: {
            protein: 0,
            carbohydrate: 5,
            fat: 7,
            flavour: 3,
        },
        omelet: {
            protein: 5,
            carbohydrate: 0,
            fat: 1,
            flavour: 1,
        },
        cheverme: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10,
        }
    }

    return (instructions) => {
        let params = instructions.split(" ");

        if(params[0] === "restock") {
            let element = params[1];
            let quantity = Number(params[2]);

            availableMicroelements[element] += quantity;

            return "Success";
        } else if(params[0] === "report"){
            return `protein=${availableMicroelements["protein"]} carbohydrate=${availableMicroelements["carbohydrate"]} fat=${availableMicroelements["fat"]} flavour=${availableMicroelements["flavour"]}`
        } else if(params[0] === "prepare") {
            let recepie = params[1];
            let quantity = Number(params[2]);

            for (const element in recepies[recepie]) {
                if (recepies[recepie][element] * quantity > availableMicroelements[element]){
                    return `Error: not enough ${element} in stock`
                }
            }

            for (const element in recepies[recepie]) {
                availableMicroelements[element] -= recepies[recepie][element] * quantity;
            }

            return "Success";
        }
    }
})();

console.log(manager("restock carbohydrate 10"));
console.log(manager("restock flavour 10"));
console.log(manager("prepare apple 1"));
console.log(manager("restock fat 10"));
console.log(manager("prepare burger 1"));
console.log(manager("report"));
console.log(manager("prepare coke 4"));     
