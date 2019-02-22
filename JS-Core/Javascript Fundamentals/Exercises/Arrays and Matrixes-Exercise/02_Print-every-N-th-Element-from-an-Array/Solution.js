function printElement(array){
    let nStep = Number(array[array.length - 1]);
    
    for (let i = 0; i < array.length - 1; i+=nStep) {
        console.log(array[i]);
    }
}