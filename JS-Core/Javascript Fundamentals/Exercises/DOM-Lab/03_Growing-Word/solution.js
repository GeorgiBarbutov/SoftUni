function solve() {
   let mouseClicks = 0;

   document.querySelector("button").addEventListener('click', () => 
   {
      let textElement = document.querySelector('#exercise p');

      if(mouseClicks % 3 === 0) {
         textElement.style.color = 'blue';
      }
      else if (mouseClicks % 3 === 1) {
         textElement.style.color = 'green';
      }
      else {
         textElement.style.color = 'red';
      }
      mouseClicks += 1;

      console.log(textElement);

      textElement.style.fontSize = `${mouseClicks * 2}px`;
   })
}