function register() {
  let usernameInput = document.getElementById("username").value;
  let emailInput = document.getElementById("email").value;
  let passswordInput = document.getElementById("password").value;

  let regex = /(.+)@(.+).(com|bg)/gm;

  if(usernameInput !== "" && regex.test(emailInput) && passswordInput !== ""){
    let outputElement = document.getElementById("result");

    let firstLine = document.createElement("h1");
    firstLine.textContent ="Successful Registration!";

    outputElement.appendChild(firstLine);
    outputElement.append(`Username: ${usernameInput}`);

    outputElement.appendChild(document.createElement("br"));
    outputElement.append(`Email: ${emailInput}`);
    outputElement.appendChild(document.createElement("br"));

    let password = '';
    for (let i = 0; i < passswordInput.length; i++) {
      password += '*';
    }

    outputElement.append(`Password: ${password}`);
    
    setTimeout(() => {
      outputElement.textContent = '';
    }, 5000);
  }
}
