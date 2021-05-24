function solve(speed, area) {
    let status = '';
    let currSpeed = speed;
    if (area === 'motorway') {
        if (currSpeed <= 130) {
            console.log(`Driving ${currSpeed} km/h in a 130 zone`);
        }
        else {
            let speedingSpeed = currSpeed - 130;
            if (speedingSpeed <= 20) {
                status = 'speeding';
            }
            else if (speedingSpeed >= 20 && speedingSpeed <= 40) {
                status = 'excessive speeding';
            }
            else {
                status = 'reckless driving';
            }
            console.log(`The speed is ${speedingSpeed} km/h faster than the allowed speed of 130 - ${status}`);
        }
    }
    else if (area === 'interstate') {
        if (currSpeed <= 90) {
            console.log(`Driving ${currSpeed} km/h in a 90 zone`);
        }
        else {
            let speedingSpeed = currSpeed - 90;
            if (speedingSpeed <= 20) {
                status = 'speeding';
            }
            else if (speedingSpeed >= 20 && speedingSpeed <= 40) {
                status = 'excessive speeding';
            }
            else {
                status = 'reckless driving';
            }
            console.log(`The speed is ${speedingSpeed} km/h faster than the allowed speed of 90 - ${status}`);
        }
    }
    else if (area === 'city') {
        if (currSpeed <= 50) {
            console.log(`Driving ${currSpeed} km/h in a 50 zone`);
        }
        else {
            let speedingSpeed = currSpeed - 50;
            if (speedingSpeed <= 20) {
                status = 'speeding';
            }
            else if (speedingSpeed >= 20 && speedingSpeed <= 40) {
                status = 'excessive speeding';
            }
            else {
                status = 'reckless driving';
            }
            console.log(`The speed is ${speedingSpeed} km/h faster than the allowed speed of 50 - ${status}`);
        }
    }
    else if (area === 'residential') {
        if (currSpeed <= 20) {
            console.log(`Driving ${currSpeed} km/h in a 20 zone`);
        }
        else {
            let speedingSpeed = currSpeed - 20;
            if (speedingSpeed <= 20) {
                status = 'speeding';
            }
            else if (speedingSpeed >= 20 && speedingSpeed <= 40) {
                status = 'excessive speeding';
            }
            else {
                status = 'reckless driving';
            }
            console.log(`The speed is ${speedingSpeed} km/h faster than the allowed speed of 20 - ${status}`);
        }
    }
}

solve(40, 'city');
solve(21, 'residential');
solve(120, 'interstate');
solve(200, 'motorway');