function solve(nums) {
    let result = [];

    for (const num of nums) {
        if (num < 0) {
            result.unshift(num);
        }
        else {
            result.push(num);
        }
    }
    for (i = 0; i < result.length; i++){
        console.log(result[i]);
    }
}

solve([7, -2, 8, 9]);