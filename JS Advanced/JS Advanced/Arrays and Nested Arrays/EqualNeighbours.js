function solve(matrix) {
    let countOfMatchesToEqualEls = 0;
    matrix.forEach((array, indexOfArray) => {
        array.forEach((currElement, indexOfEl) => {
            let nextElement = array[indexOfEl + 1];
            if (nextElement === currElement) countOfMatchesToEqualEls++;
            if (matrix[indexOfArray + 1] != undefined) {
                let elementToDownSide = matrix[indexOfArray + 1][indexOfEl];
                if (elementToDownSide === currElement) countOfMatchesToEqualEls++;
            }
        });
    });
    return countOfMatchesToEqualEls;
}

console.log(solve([['2', '3', '4', '7', '0'],
['4', '0', '5', '3', '4'],
['2', '3', '5', '4', '2'],
['9', '8', '7', '5', '4']]));