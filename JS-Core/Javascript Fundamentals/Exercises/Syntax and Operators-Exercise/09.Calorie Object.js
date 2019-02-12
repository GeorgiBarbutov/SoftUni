function solve(array) {
    let object = {};

    for (let i = 0; i < array.length; i+=2) {
        object[array[i]] = +array[i + 1];
    }

    console.log(object);
}