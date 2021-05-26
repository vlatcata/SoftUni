function solve(nums) {
    let firstNum = Number(nums.shift());
    let lastNum = Number(nums.pop());

    console.log(firstNum + lastNum);
}

solve(['20', '30', '40']);