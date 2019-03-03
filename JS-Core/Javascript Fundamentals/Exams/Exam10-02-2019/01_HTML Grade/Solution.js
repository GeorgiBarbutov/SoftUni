function htmlGrade(examPoint, homeworkCompleted, totalHomework){
    let finalGrade;

    if(examPoint === 400){
        finalGrade = 6;
    } else {
        let totalPoints = (90 * (examPoint / 400)) + (10 * (homeworkCompleted / totalHomework));

        finalGrade = 3 + 2 * (totalPoints - 100 / 5) / (100 / 2);

        if(finalGrade < 3){
            finalGrade = 2;
        } else if(finalGrade > 6){
            finalGrade = 6;
        }
    }

    console.log(finalGrade.toFixed(2));
}