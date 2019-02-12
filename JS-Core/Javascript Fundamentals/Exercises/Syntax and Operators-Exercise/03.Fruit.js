function calculate(fruit, weightNeeded, pricePerKilo) {
    let totalPrice = weightNeeded * pricePerKilo;

    console.log(
        `I need ${(totalPrice / 1000).toFixed(2)} leva to buy ${(weightNeeded / 1000).toFixed(2)} kilograms ${fruit}.`);
}