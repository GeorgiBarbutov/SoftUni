function solve() {
   let number = Number(document.getElementById("num").value);

   let result = "1"; 

   factorial(number);

   let resultElement = document.getElementById("result");
   resultElement.textContent = result;

   function factorial(number) {
      for (let i = 2; i <= number; i++) {
         if (number % i === 0) {
            result += ` ${i}`;
         }
      }
   }
}