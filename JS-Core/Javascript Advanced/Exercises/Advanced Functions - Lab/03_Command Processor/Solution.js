function commandProcessor(arr){
    let func = (function executeCommand(){
        let string = "";
    
        return {
            append: (str) => string += str,
            removeStart: (n) => string = string.substring(n),
            removeEnd: (n) => string = string.substring(0, string.length - n),
            print: () => console.log(string)
        }   
    })();
    
    for (let i = 0; i < arr.length; i++) {
        let command = arr[i].split(" ")[0];
        let argument = arr[i].split(" ")[1];
        
        if(command === "append"){
            func.append(argument);
        } else if(command === "removeStart") {
            func.removeStart(Number(argument));
        } else if(command === "removeEnd") {
            func.removeEnd(Number(argument));
        }  else if(command === "print") {
            func.print();
        }
    }
}



commandProcessor(['append hello',
'append again',
'removeStart 3',
'removeEnd 4',
'print']
)