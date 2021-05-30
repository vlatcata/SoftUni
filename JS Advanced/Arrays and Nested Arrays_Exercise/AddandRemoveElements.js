function solve(array) {
    let moddedArray = [];
    let numToAdd = 0;
    for (let i = 0; i < array.length; i++) {
        numToAdd++;
        if (array[i] == 'add') {
            moddedArray.push(numToAdd);
        }
        else {
            moddedArray.pop();
        }
    }
    if (moddedArray.length <= 0) {
        console.log('Empty');
    }
    return moddedArray.join('\n');
}

console.log(solve(['remove', 
'remove', 
'remove']
));