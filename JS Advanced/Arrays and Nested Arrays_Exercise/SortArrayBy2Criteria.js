function solve(input) {
    input.sort((a, b) => a - b);
    input.sort((a, b) => a.length - b.length);
    input.sort((a, b) => a.toLowerCase().localeCompare(b.toLowerCase()));
    return input.join('\n');
}

console.log(solve(['alpha', 
'beta', 
'gamma']));