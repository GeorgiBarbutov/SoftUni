function aggregates(array){
    let sum = array.reduce((previous, current) => previous + current);

    let min = array.reduce((previous, current) => {
        if(previous < current) {
            return previous;
        } else {
            return current;
        }
    });

    let max = array.reduce((previous, current) => {
        if(previous < current) {
            return current;
        } else {
            return previous;
        }
    });

    let product = array.reduce((previous, current) => previous * current);

    let join = array.map(n => n.toString()).reduce((previous, current) => previous + current);
    
    console.log(`Sum = ${sum}`);
    console.log(`Min = ${min}`);
    console.log(`Max = ${max}`);
    console.log(`Product = ${product}`);
    console.log(`Join = ${join}`);

}

aggregates([1, 2, 3, 4]);