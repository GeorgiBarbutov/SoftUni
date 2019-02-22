function addRemove(commands){
    let number = 1;
    let array = [];

    for (const command of commands) {
        if(command === "add") {
            array.push(number);
            number += 1;
        } else {
            array.pop();
            number += 1;
        }
    }

    if(array.length === 0){
        console.log("Empty");
    } else {
        for (let i = 0; i < array.length; i++) {
            console.log(array[i]);
        }
    }
}