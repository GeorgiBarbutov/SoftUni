function calculateArea(radius){
    let type = typeof(radius);

    if(type === "number")
    {
        let area = (Math.PI * Math.pow(radius, 2)).toFixed(2); 

        console.log(area);
    }
    else
    {
        console.log(`We can not calculate the circle area, because we receive a ${type}.`);
    }
}

calculateArea(3);
calculateArea("aa");
calculateArea({});