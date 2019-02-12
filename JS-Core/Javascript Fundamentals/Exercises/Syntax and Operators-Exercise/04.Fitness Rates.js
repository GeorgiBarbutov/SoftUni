function getRate(dayOfWeek, activity, hourInput) {
    let hour = +hourInput;
    
    let result;

    if (activity === "Fitness") {
        if (hour >= 8 && hour <= 15) {
            if(dayOfWeek == "Monday" || dayOfWeek == "Tuesday" || dayOfWeek == "Wednesday" || dayOfWeek == "Thursday" || dayOfWeek == "Friday") {
                result = 5;
            }
            else if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday") {
                result = 8;
            }
        }
        else if (hour > 15 && hour <= 22) {
            if(dayOfWeek == "Monday" || dayOfWeek == "Tuesday" || dayOfWeek == "Wednesday" || dayOfWeek == "Thursday" || dayOfWeek == "Friday") {
                result = 7.5;
            }
            else if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday") {
                result = 8;
            }
        }
    }
    else if (activity === "Sauna") {
        if (hour >= 8 && hour <= 15) {
            if(dayOfWeek == "Monday" || dayOfWeek == "Tuesday" || dayOfWeek == "Wednesday" || dayOfWeek == "Thursday" || dayOfWeek == "Friday") {
                result = 4;
            }
            else if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday") {
                result = 7;
            }
        }
        else if (hour > 15 && hour <= 22) {
            if(dayOfWeek == "Monday" || dayOfWeek == "Tuesday" || dayOfWeek == "Wednesday" || dayOfWeek == "Thursday" || dayOfWeek == "Friday") {
                result = 6.5;
            }
            else if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday") {
                result = 7;
            }
        }
    }
    else if (activity === "Instructor") {
        if (hour >= 8 && hour <= 15) {
            if(dayOfWeek == "Monday" || dayOfWeek == "Tuesday" || dayOfWeek == "Wednesday" || dayOfWeek == "Thursday" || dayOfWeek == "Friday") {
                result = 10;
            }
            else if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday") {
                result = 15;
            }
        }
        else if (hour > 15 && hour <= 22) {
            if(dayOfWeek == "Monday" || dayOfWeek == "Tuesday" || dayOfWeek == "Wednesday" || dayOfWeek == "Thursday" || dayOfWeek == "Friday") {
                result = 12.5;
            }
            else if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday") {
                result = 15;
            }
        }
    }

    console.log(result);
}

getRate("Monday", "Sauna", 15.30);