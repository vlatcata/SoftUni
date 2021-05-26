function solve(array) {
    let result = [];
    for (let i = 0; i < array.length; i++) {
        if (i % 2 != 0) {
            result += array[i] * 2 + ' ';
        }
    }
    let reversed = result.reverse();
    return reversed;
}

console.log(solve([10, 15, 20, 25]));