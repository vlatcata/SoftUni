function solve(text) {
    let words = text.match(/\w+/gim);

    let result = ''
    for (const word of words) {
       result += word.toUpperCase() + ', '; 
    }
    result = result.substring(0, result.length - 2);
    return result;
}

console.log(solve('Hi, how are you?'));
console.log(solve('hello'));