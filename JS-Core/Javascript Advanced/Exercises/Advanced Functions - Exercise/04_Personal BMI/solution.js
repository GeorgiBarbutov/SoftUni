function personalBMI(name, age, weight, height) {
    let BMI = Number((weight / ((height / 100) * (height / 100))).toFixed(0));

    let status = "";

    if(BMI < 18.5){
        status = "underweight";
    } else if(BMI >= 18.5 && BMI < 25){
        status = "normal";
    } else if(BMI >= 25 && BMI < 30){
        status = "overweight";
    } else if(BMI >= 30){
        status = "obese";
    }
    
    let info = {
        name: name,
        personalInfo: {
            age: age,
            weight: weight,
            height: height
        },
        BMI: BMI,
        status: status
    };

    if(status === "obese"){
        info["recommendation"] = "admission required";
    }

    return info;
}

console.log(personalBMI("Honey Boo Boo", 9, 57, 137));