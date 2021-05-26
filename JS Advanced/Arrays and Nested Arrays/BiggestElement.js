function solve(array) {
    let biggestNum = 0;
    for (let i = 0; i < array.length; i++) {
        for (let j = 0; j < array.length; j++) {
            const element = array[j];
            if (element > biggestNum) {
                biggestNum = element;
            }
        }
    }
    return biggestNum;
}

console.log(solve([[20, 50, 10],
    [8, 33, 145]]));