function solution(currencyFormatter){
    return (value) => currencyFormatter(",", "$", true, value);
}

function currencyFormatter(separator, symbol, symbolFirst, value) {
    let result = Math.trunc(value) + separator;
    result += value.toFixed(2).substr(-2,2);
    if (symbolFirst) return symbol + ' ' + result;
    else return result + ' ' + symbol;
}

let dolarFormater = solution(currencyFormatter)(4.65);
console.log(dolarFormater);
