function leapYear() {
    let button = document.querySelector("#exercise button");
    button.addEventListener("click", () => buttonPress())

    function checkYear(year){
        return (+year % 4 === 0 && +year % 100 !== 0) || +year % 400 === 0;
    }

    function buttonPress(){
        let year = Number(document.querySelector("#exercise input").value);

        let isLeapYear = checkYear(year);

        let h2 = document.querySelector("#year h2");

        if(isLeapYear){
            h2.textContent = "Leap Year";
        } else {
            h2.textContent = "Not Leap Year";
        }

        let div = document.querySelector("#year div");

        div.textContent = year;
    
        document.querySelector("#exercise input").value = "";
    }

}