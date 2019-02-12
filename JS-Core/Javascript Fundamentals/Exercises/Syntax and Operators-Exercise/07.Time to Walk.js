function CalculateWalkingDistance(steps, lengthOfFootprint, speed) {
    let distanceToUniversity = steps * lengthOfFootprint;
    
    let totalBreak = Math.floor(distanceToUniversity / 500);

    let totalSeconds = (distanceToUniversity / speed  * 3.6).toFixed(0);

    let seconds = (totalSeconds % 60).toFixed(0);

    let minutes = Math.floor(totalSeconds / 60 % 60) + totalBreak;

    let hours = Math.floor(totalSeconds / 60 / 60 % 60);

    if(hours < 10) {
        hours = '0' + hours;
    }
    if(minutes < 10) {
        minutes = '0' + minutes;
    }
    if(seconds < 10) {
        seconds = '0' + seconds;
    }

    console.log(`${hours}:${minutes}:${seconds}`);
}

CalculateWalkingDistance(4000, 0.60, 5);