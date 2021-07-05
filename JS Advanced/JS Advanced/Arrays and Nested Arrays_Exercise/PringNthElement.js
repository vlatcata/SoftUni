function solve(array, num) {
    let newArr = [];
    for (let i = 0; i < array.length; i++) {
        if (i % num == 0) {
            newArr.push(array[i]);
        }
    }
    return newArr;
}

console.log(solve(['5', 
'20', 
'31', 
'4', 
'20'], 
2));