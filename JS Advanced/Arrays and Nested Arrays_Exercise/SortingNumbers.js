function solve(input) {
    let newArr = [];
    let originalLength = input.length;
    input.sort((a, b) => a - b);
    for (let i = 0; i < originalLength / 2; i++) {
        let smallNum = input.shift();
        let bigNum = input.pop();
        newArr.push(smallNum);
        newArr.push(bigNum);
    }

    return newArr;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));