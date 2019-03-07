function sortArray(arr, order){
    let sortingStrategy;

    if(order === "asc") {
        sortingStrategy = (a, b) => a - b; 
    } else {
        sortingStrategy = (a, b) => b - a;
    }
    
    return arr.sort(sortingStrategy);
}