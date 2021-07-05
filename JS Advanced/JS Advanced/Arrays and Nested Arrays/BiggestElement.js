function solve(matrixArray) {
    let biggestNumber = Number.MIN_SAFE_INTEGER;
    matrixArray.forEach(arr => {
        let currBiggestNum = Math.max(...arr); //Splits the array 
        if (currBiggestNum > biggestNumber) biggestNumber = currBiggestNum;
    });
    return biggestNumber;
}

console.log(solve([[20, 50, 10],
    [8, 33, 145]]));