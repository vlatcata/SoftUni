function solve(array) {
    let result = '';
    for (let i = 0; i < array.length; i++) {
        if (i % 2 == 0) {
            result += array[i] + ' ';
        }
    }
    console.log(result);
}

solve(['20', '30', '40', '50', '60']);