function solve(...params) {
    let occurances = {};
    let result = [];
    for (let i = 0; i < params.length; i++) {
        let type = typeof(params[i]);
        result.push(`${type}: ${params[i]}`);
        occurances[type] = occurances[type] !== undefined ? ++occurances[type] : 1;
    };

    Object.keys(occurances).sort((a, b) => occurances[b] - occurances[a]).forEach(key => result.push(`${key} = ${occurances[key]}`));

    return result.join('\n');
};

console.log(solve('cat', 42, function () { console.log('Hello world!'); }));