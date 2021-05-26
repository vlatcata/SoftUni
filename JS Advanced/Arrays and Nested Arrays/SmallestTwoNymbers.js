function solve(array) {
    array.sort((a, b) => a - b);
    let modifirdArray = array.slice(0, 2);
    console.log(modifirdArray);
}


solve([3, 0, 10, 4, 7, 3]);