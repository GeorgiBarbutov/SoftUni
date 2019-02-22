function sortArray(array) {
    array = array.sort((a, b) => {
        if(a.length === b.length){
            return a > b;
        } else return a.length - b.length;
    });

    for (let i = 0; i < array.length; i++) {
        console.log(array[i]);
    }
}

sortArray(["test", "Deny", "omen", "Default"])