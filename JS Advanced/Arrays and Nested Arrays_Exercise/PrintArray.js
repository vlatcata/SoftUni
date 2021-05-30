function solve(array, delimeter) {
    let newArray = array.join(delimeter);
    return newArray;
}

console.log(solve(['One', 
'Two', 
'Three', 
'Four', 
'Five'], 
'-'));