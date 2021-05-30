function solve(array) {
    let newArr = [];
    newArr.push(array[0]);
    let currBiggest = array[0];
    for (let i = 0; i < array.length; i++) {
        if (array[i + 1] > currBiggest) {
            currBiggest = array[i + 1];
            newArr.push(array[i + 1])
        }
    }
    return newArr;
}

console.log(solve([1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24]));