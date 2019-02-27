function solve() {
    let input = document.getElementById("str").value;
    let result = document.getElementById("result");

    let info = input.split(",")[0];
    let command = input.split(",")[1].trim();

    let nameRegex = / [A-Z][a-zA-Z]*-([A-Z][a-zA-Z]*|[A-Z][a-zA-Z]*\.-[A-Z][a-zA-Z]*) /;

    let name = info.match(nameRegex)[0].trim().replace(/-/g, " ");

    let airportRegex = / ([A-Z]{3})\/([A-Z]{3}) /;

    let airportMatch = info.match(airportRegex);

    let fromAirport = airportMatch[1];
    let toAirport = airportMatch[2];

    let flighNumberRegex = / [A-Z]{1,3}\d{1,5} /;

    let flightNumber = info.match(flighNumberRegex)[0].trim();

    let companyNameRegex = /- ([A-Z][a-zA-Z]*\*[A-Z][a-zA-Z]*) /;

    let companyName = info.match(companyNameRegex)[1].replace("*", " ");

    let output = "";
    if(command === "name"){
        output = `Mr/Ms, ${name}, have a nice flight!`
    } else if(command === "flight") {
        output = `Your flight number ${flightNumber} is from ${fromAirport} to ${toAirport}.`;
    } else if (command === "company") {
        output = `Have a nice flight with ${companyName}.`
    } else if(command === "all") {
        output = `Mr/Ms, ${name}, your flight number ${flightNumber} is from ${fromAirport} to ${toAirport}. Have a nice flight with ${companyName}.`;
    }

    result.textContent = output;
}