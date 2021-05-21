function solve(array){

    let sum = 0;
    for (let num of array) {
        sum += num;
    }

    let sum2 = 0;
    for (let num of array) {
        sum2 += 1 / num;
    }

    let sum3 = '';
    for (let num of array) {
        sum3 += num;
    }

    console.log(sum);
    console.log(sum2);
    console.log(sum3);
}

solve([2, 4, 8, 16]);
solve([1, 2, 3]);