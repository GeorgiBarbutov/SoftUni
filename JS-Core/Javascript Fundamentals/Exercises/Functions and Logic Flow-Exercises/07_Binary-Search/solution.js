function binarySearch() {
    let arrInput = String(document.getElementById("arr").value);
    let numberToFind = Number(document.getElementById("num").value);

    let arr = arrInput.split(", ").map((s) => Number(s));

    let isFound = false;
    let middleIndex = 0;
    let foundIndex = 0

    do { 
        middleIndex = Math.floor(arr.length / 2);

        if(numberToFind < arr[middleIndex]) {
            arr = arr.filter((number) => number < arr[middleIndex]);

        } else if (numberToFind > arr[middleIndex]){
            arr = arr.filter((number) => number > arr[middleIndex]);
            foundIndex += middleIndex + 1;
            
        } else {
            isFound = true;
            foundIndex += middleIndex;
            break;
        }
    } while(!isFound && arr.length > 0);

    let result = document.getElementById("result");

    if(isFound){
        result.textContent = `Found ${numberToFind} at index ${foundIndex}`;
    } else {
        result.textContent = `${numberToFind} is not in the array`;
    }
}