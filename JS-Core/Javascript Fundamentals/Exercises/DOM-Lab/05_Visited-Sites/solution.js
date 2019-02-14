function solve() {
  let allLinks = document.querySelectorAll("a");

  for (let i = 0; i < allLinks.length; i++) {
    allLinks[i].addEventListener("click", () =>{
      let allSpans = document.querySelectorAll("span");

      let currentClicks = +allSpans[i].textContent.split(' ')[1];

      allSpans[i].textContent = `Visited: ${currentClicks += 1} times`;
    })
  }
}