function solve(array) {
    let arr = [];
    for (let i = 0; i < array.length; i++) {
        if (i % 2 != 0) {
            arr += array[i] * 2 + ' ';
        }
    }
    let reversed = arr.toString().split(' ').reverse().join("\n");
    return reversed;
}

console.log(solve([10, 15, 20, 25]));