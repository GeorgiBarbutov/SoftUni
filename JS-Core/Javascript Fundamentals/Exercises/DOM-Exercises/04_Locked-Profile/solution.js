function solve() {
   let buttons = document.getElementsByTagName("button");

   for (let i = 0; i < buttons.length; i++) {
      buttons[i].addEventListener("click", () => ButtonPress(i))
   }

   function ButtonPress(index){
      let profile = document.getElementsByClassName("profile")[index];
      let hiddenFields = profile.querySelector(`#user${index + 1}HiddenFields`);

      let isLocked = profile.querySelector(`input[name=user${index + 1}Locked]:checked`).value === "lock";

      let isHidden = buttons[index].textContent === "Show more";

      if(!isLocked) {
         if(isHidden) {
            hiddenFields.style.display = "initial";

            buttons[index].textContent = "Hide it";
         }
         if(!isHidden) {
            hiddenFields.style.display = "none";

            buttons[index].textContent = "Show more";
         }
      }
   }
} 