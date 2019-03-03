function htmlStrictMode(htmlInput){
    let result = [];

    for (let i = 0; i < htmlInput.length; i++) {
        let isValid = true;

        let backArrowsCount = 0;
        let forwardArrowsCount = 0;

        for (let j = 0; j < htmlInput[i].length; j++) {
            if(htmlInput[i][j] === "<"){
                backArrowsCount += 1;
            } else if(htmlInput[i][j] === ">"){
                forwardArrowsCount += 1;
            }
        }
        
        if(backArrowsCount % 2 !== 0 || forwardArrowsCount % 2 !== 0) {
            isValid = false;
        }

        backArrowsCount /= 2;

        if(htmlInput[i][0] !== "<"){
            isValid = false;
        }

        let iteration = 0;
        let previousFirstMatchOfBackArrowIndex = -1;
        let previousFirstMatchOfForwardArrowIndex = -1;
        let previousLastMatchOfBackArrowIndex = htmlInput[i].length;
        let previousLastMatchOfForwardArrowIndex = htmlInput[i].length;

        while(isValid && iteration !== backArrowsCount) {
            iteration += 1;

            let firstMatchOfBackArrow = htmlInput[i].indexOf("<", previousFirstMatchOfBackArrowIndex + 1);
            previousFirstMatchOfBackArrowIndex = firstMatchOfBackArrow;

            let firstMatchOfForwardArrow = htmlInput[i].indexOf(">", previousFirstMatchOfForwardArrowIndex + 1);
            previousFirstMatchOfForwardArrowIndex = firstMatchOfForwardArrow;

            let firstTagName = htmlInput[i].substring(firstMatchOfBackArrow + 1, firstMatchOfForwardArrow);

            let lastMatchOfBackArrow = htmlInput[i].lastIndexOf("<", previousLastMatchOfBackArrowIndex - 1);
            previousLastMatchOfBackArrowIndex = lastMatchOfBackArrow;

            let lastMatchOfForwardArrow = htmlInput[i].lastIndexOf(">", previousLastMatchOfForwardArrowIndex - 1);
            previousLastMatchOfForwardArrowIndex = lastMatchOfForwardArrow;

            let lastTagName = htmlInput[i].substring(lastMatchOfBackArrow + 2, lastMatchOfForwardArrow);

            if(firstTagName !== lastTagName || !/\w/.test(firstTagName) || !/\w/.test(lastTagName)){
                isValid = false;
            }
        } 

        if(isValid) {
            let replacedText = htmlInput[i].replace(/(<\w+>)|(<\/\w+>)/g, "");

            result.push(replacedText);
        }
    }

    console.log(result.join(" "));
}

htmlStrictMode(['FFFF',
'FFF',
' ',
''])