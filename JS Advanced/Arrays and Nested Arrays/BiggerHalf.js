function solve(array) {
    array.sort((a, b) => a - b);
    let modifiedArray = array.slice(array.length / 2);
    return modifiedArray;
}

console.log(solve([3, 19, 14, 7, 2, 19, 6]));