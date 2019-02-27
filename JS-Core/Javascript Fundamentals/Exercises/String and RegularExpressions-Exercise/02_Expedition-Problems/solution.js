function solve() {
  let inputString = document.getElementById("str").value;
  let inputText = document.getElementById("text").value;
  let result = document.getElementById("result");

  let messageRegex = new RegExp(`${inputString}(.*)${inputString}`, "i");
  let message = messageRegex.exec(inputText)[1];

  let matches = [];
  let i = 0;
  let regex = /(east|north).*?(\d{2})[^,]*,[^,]*(\d{6})/gi;

  do {
    matches[i] = regex.exec(inputText);
    i++;
  } while (matches[i - 1] !== null);

  matches = matches.filter(arr => arr !== null);

  let eastMatches = matches.filter(arr => arr[1].toLowerCase() === "east");
  let northMatches = matches.filter(arr => arr[1].toLowerCase() === "north");

  let lastEastMatch = eastMatches[eastMatches.length - 1];
  let lastNorthMatch = northMatches[northMatches.length - 1];

  appendParagraph(lastNorthMatch, "N");
  appendParagraph(lastEastMatch, "E");
  
  let paragraph = document.createElement("p");
  paragraph.textContent = (`Message: ${message}`);
  result.appendChild(paragraph);

  function appendParagraph(match, direction) {
    let paragraph = document.createElement("p");

    paragraph.innerText = `${match[2]}.${match[3]} ${direction}`;

    result.appendChild(paragraph);
  }
}