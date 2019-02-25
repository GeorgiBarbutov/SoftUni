function solve() {
  let inputArray = JSON.parse(document.getElementById("arr").value);

  let result = document.getElementById("result");

  for (const element of inputArray) {
    let newLine = document.createElement("p");
    newLine.textContent = "- - -";

    let regex = new RegExp((/([A-Z]{1}[a-z]* [A-Z]{1}[a-z]*) (\+359(( [0-9]{1} [0-9]{3} [0-9]{3})|(-[0-9]{1}-[0-9]{3}-[0-9]{3}))) ([a-z0-9]+@[a-z]+.[a-z]{2,3})/));
    
    if(regex.test(element)){
      let matches = regex.exec(element);
      
      let nameP = document.createElement("p");
      let name = matches[1]; 
      nameP.textContent = `Name: ${name}`;
      
      result.appendChild(nameP);

      let phoneP = document.createElement("p");
      let phoneNumber = matches[2]; 
      phoneP.textContent = `Phone Number: ${phoneNumber}`;

      result.appendChild(phoneP);

      let emailP = document.createElement("p");
      let email = matches[6]; 
      emailP.textContent = `Email: ${email}`;

      result.appendChild(emailP);

      result.appendChild(newLine);
    } else {
      let p = document.createElement("p");

      p.textContent = "Invalid data";

      result.appendChild(p);

      result.appendChild(newLine);
    }
  }
}