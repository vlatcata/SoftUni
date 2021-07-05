function solve(array, rotations) {
    let realRotations = rotations % array.length;
    for (let i = 0; i < realRotations; i++) {
        let currElement = array.pop();
        array.unshift(currElement);
    }
    let nums = array.join(' ');
    return nums;
}

console.log(solve(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15));