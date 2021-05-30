function solve(names) {
    names.sort();
    let stringNames = '';
    for (let i = 0; i < names.length; i++) {
        stringNames += `${i + 1}.${names[i]} \n`;
    }
    return stringNames.trimEnd();
}

console.log(solve(["John", "Bob", "Christina", "Ema"]));