function validate() {
    let button = document.querySelector("#exercise div button");
    button.addEventListener("click", () => buttonClick());

    function buttonClick() {
        let year = Number(document.getElementById("year").value);
        let month = Number(document.getElementById("month").value);
        let date = Number(document.getElementById("date").value);
        let isMale = document.getElementById("male").checked;
        let regionalCode = Number(document.getElementById("region").value);

        let yearString = "" + year[2] + year[3];
        
        let monthString = "";
        if(month >= 10){
            monthString += month;
        } else {
            monthString += "0" + month;
        }
        let dateString = "";
        if(date >= 10){
            dateString += date;
        } else {
            dateString += "0" + date;
        }

        let egn = yearString + monthString + dateString
        
        //Unfinished
    }
}