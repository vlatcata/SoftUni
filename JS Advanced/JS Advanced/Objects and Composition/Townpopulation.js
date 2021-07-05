function solve(input) {
    let result = {};
    
    input.forEach(e => {
        const [key, value] = e.split(' <-> ');
        if (result[key] != undefined) {
            result[key] += Number(value);
        } else {
            result[key] = Number(value);
        }
    });

    for (const el in result) {
        console.log(`${el} : ${result[el]}`);
    }
}

console.log(solve(['Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000']));